using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AssetPostProcessors.CustomProcessors
{
    public class MyCustomProcessor : CustomProcessor
    {
        public override void Settings() => assetsTypes = PostProcessorAssetsTypes.ImportedAssets;

        public override void PostProcessAssets()
        {
            foreach (string assetPath in assets)
                Perform(assetPath);
        }

        public override void Perform(string assetPath)
        {
            Debug.Log("File found :" + assetPath);
        }

    }
}
