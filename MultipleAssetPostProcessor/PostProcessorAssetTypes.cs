using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetPostProcessors
{
    [Flags]
    public enum PostProcessorAssetsTypes
    {
        ImportedAssets = 1,
        DeletedAssets = 2,
        MovedAssets = 4,
        MovedFromAssetPaths = 8,

        UseAllAssets = ImportedAssets | DeletedAssets | MovedAssets | MovedFromAssetPaths,
    }
}
