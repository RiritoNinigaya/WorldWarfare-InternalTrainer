using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using UnityEngine.AI;
using HarmonyLib;
using HarmonyXInterop;
using BepInEx.Logging;
using WWE;
using static UnityEngine.Rendering.DebugUI;
using System.IO;
using UnityEngine.SocialPlatforms;

namespace WorldWarfare_InternalTrainer
{
    [BepInPlugin("b71343eb-f044-4077-ad55-b6adf27dc1d9", "World Warfare Internal Trainer by RiritoNinigaya", "1.0")]
    public class WorldWarfareTrainer : BaseUnityPlugin
    {
        public enum HarmonyPatchEnum : int
        {
            Success = 1,
            Failed = 2,
            Harmony_NotCreatedFolder = 3
        }
        public static bool _gamespeed4000;
        private void Awake()
        {
            Logger.LogMessage("Initializated Successfully!!!");
            Harmony.CreateAndPatchAll(typeof(CountriesPatch));
        }
        private void OnGUI()
        {
            GUI.Box(new Rect(35, 35, 400, 400), "WorldWarfare InternalTrainer by RiritoNinigaya");
            GUILayout.BeginArea(new Rect(35, 35, 455, 455));
            _gamespeed4000 = GUILayout.Toggle(_gamespeed4000, "Set Game Speed As 4000");
            if (_gamespeed4000 == true)
            {
                UnityEngine.Time.timeScale = 4000f;
                float string_float = Time.timeScale;
                string float_value = string_float.ToString();
                Directory.CreateDirectory("C:\\WorldWarfare");
                File.WriteAllText("C:\\WorldWarfare\\WWE.txt", "-".Replace("-", float_value));
            }
        }
    }
    [HarmonyPatch(typeof(Countries))]
    public class CountriesPatch
    {
        /*
                    [HarmonyPatch(nameof(Countries.OnPlayerStartTechResearch))]
        [HarmonyPrefix]
        public void OnPlayerStartTechResearchPatched()
        {
            Tech.Type type_military = Tech.Type.Military;
            Tech.
        } 
        */
    }
}
