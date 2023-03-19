using AssetPostProcessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace AssetPostProcessors
{

    public class PostProcessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload) { }

        public static Type[] GetCustomProcessors()
        {
            Type[] classes = Assembly.GetExecutingAssembly().GetTypes();
            return classes.Where(t => t.Namespace == "AssetPostProcessors.CustomProcessors" && t.IsClass && t.IsPublic).ToArray();
        }
    }

    public abstract class CustomProcessor { }

}

namespace AssetPostProcessors.CustomProcessors
{
    public class MyCustomProcessor : CustomProcessor { }
}
