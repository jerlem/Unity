using AssetPostProcessors.CustomProcessors;
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace AssetPostProcessors
{

    public class PostProcessor : AssetPostprocessor
    {
        public static Type[] CustomProcessorsArgsType => new Type[] { typeof(string[]), typeof(string[]), typeof(string[]), typeof(string[]) };

        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, 
            string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
        {
            Type[] customProcessors = GetCustomProcessors();

            foreach (Type type in customProcessors)
            {
                CustomProcessor instance = Activator.CreateInstance(type) as CustomProcessor;
                MethodInfo method = type.GetMethod("CustomProcessorInvoker", CustomProcessorsArgsType);

                if (method != null)
                {
                    method.Invoke(instance, new object[] { importedAssets, deletedAssets, movedAssets, movedFromAssetPaths });
                }
            }
        }

        public static Type[] GetCustomProcessors()
        {
            Type[] classes = Assembly.GetExecutingAssembly().GetTypes();
            return classes.Where(t => t.Namespace == "AssetPostProcessors.CustomProcessors" && t.IsClass && t.IsPublic).ToArray();
        }
    }

}
