﻿using System;
using BepInEx;
using KKAPI.Chara;
using KKAPI.Maker;
using Manager;
using UnityEngine;

namespace KKAPI
{
    [BepInPlugin(GUID, "Modding API", VersionConst)]
    public partial class KoikatuAPI : BaseUnityPlugin
    {
        private void Awake()
        {
            var insideStudio = Application.productName == "CharaStudio";
            MakerAPI.Init(insideStudio);
            CharacterApi.Init();
        }

        private void Start()
        {
            // Needs to be called after moreaccessories has a chance to load
            AccessoriesApi.Init();
        }

        /// <summary>
        /// Get current game mode. 
        /// </summary>
        public static GameMode GetCurrentGameMode()
        {
            if (MakerAPI.InsideMaker) return GameMode.Maker;
            if (Game.Instance.WorldData != null) return GameMode.MainGame;
            return GameMode.Unknown;
        }

        /// <summary>
        /// Get current version of the game.
        /// </summary>
        public static Version GetGameVersion()
        {
            return Game.Version;
        }
    }
}
