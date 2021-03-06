﻿using System;
using System.Collections.Generic;
using System.Linq;
using FeatureType = Bimangle.ForgeEngine.Common.Formats.Cesium3DTiles.FeatureType;

namespace Bimangle.ForgeEngine.Revit.Config
{
    [Serializable]
    class AppConfigCesium3DTiles
    {
        public string LastTargetPath { get; set; }
        public bool AutoOpenAllow { get; set; }
        public string AutoOpenAppName { get; set; }
        public string VisualStyle { get; set; }
        public int LevelOfDetail { get; set; }
        public List<FeatureType> Features { get; set; }

        /// <summary>
        /// 工作模式
        /// </summary>
        /// <remarks>
        /// 0: 基本模式
        /// 1: 室内室外分别优化
        /// 2: 抽壳模式 - Mesh 级
        /// 3: 抽壳模式 - 构件 级
        /// </remarks>
        public int Mode { get; set; }

        public AppConfigCesium3DTiles()
        {
            LastTargetPath = string.Empty;
            AutoOpenAllow = true;
            AutoOpenAppName = null;
            VisualStyle = null;
            LevelOfDetail = 6;  //默认为 6
            Features = new List<FeatureType>
            {
                FeatureType.ExcludeLines,
                FeatureType.ExcludePoints,
                FeatureType.GenerateModelsDb,
                FeatureType.EnableQuantizedAttributes,
                FeatureType.ExcludeTexture,
                FeatureType.UseViewOverrideGraphic,
                FeatureType.EnableTextureWebP,
                FeatureType.EnableEmbedGeoreferencing,
                // FeatureType.EnableUnlitMaterials
            };
            Mode = 0;
        }

        public AppConfigCesium3DTiles Clone()
        {
            return new AppConfigCesium3DTiles
            {
                LastTargetPath = LastTargetPath,
                AutoOpenAllow = AutoOpenAllow,
                AutoOpenAppName = AutoOpenAppName,
                VisualStyle = VisualStyle,
                LevelOfDetail = LevelOfDetail,
                Features = Features?.ToList() ?? new List<FeatureType>(),
                Mode = Mode
            };
        }
    }
}
