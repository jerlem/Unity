using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetPostProcessors.CustomProcessors
{
    public abstract class CustomProcessor
    {
        protected List<string> assets = new();
        protected PostProcessorAssetsTypes assetsTypes;

        public void CustomProcessorInvoker(string[] importedAssets, string[] deletedAssets,
            string[] movedAssets, string[] movedFromAssetPaths)
        {
            Settings();

            if (assetsTypes.HasFlag(PostProcessorAssetsTypes.ImportedAssets)) assets.AddRange(importedAssets);
            if (assetsTypes.HasFlag(PostProcessorAssetsTypes.DeletedAssets)) assets.AddRange(deletedAssets);
            if (assetsTypes.HasFlag(PostProcessorAssetsTypes.MovedAssets)) assets.AddRange(movedAssets);
            if (assetsTypes.HasFlag(PostProcessorAssetsTypes.MovedFromAssetPaths)) assets.AddRange(movedFromAssetPaths);

            PostProcessAssets();
        }

        public abstract void Settings();
        public abstract void PostProcessAssets();
        public abstract void Perform(string assetPath);
    }

}
