using System;
using BepInEx;
using UnityEngine;
using Newtilla;


namespace bringbacklavaupdate
{



    [BepInDependency("Lofiat.Newtilla", "1.1.0")]
    [BepInIncompatibility("org.iidk.gorillatag.iimenu")]
	[BepInIncompatibility("com.goldentrophy.gorillatag.nametags")]
	[BepInIncompatibility("com.dedouwe26.gorillatag.cosmetx")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{

            Newtilla.Newtilla.OnJoinModded += OnModdedJoined;
            Newtilla.Newtilla.OnLeaveModded += OnModdedLeft;
        }

		void OnEnable()
		{
			/* Set up your mod here */
			/* Code here runs at the start and whenever your mod is enabled*/

			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
            GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

		void Update()
		{
			/*if (inRoom)
			{
				GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
				lava.SetActive(true);
			}
			else
			{
                GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
                lava.SetActive(false);
            }*/
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */

        void OnModdedJoined(string modeName)
        {
            GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV/").transform.GetChild(0).gameObject.SetActive(false);//the lava
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV/").transform.GetChild(2).gameObject.SetActive(false);//the buckets
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV/").transform.GetChild(4).gameObject.SetActive(false);//
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV/").transform.GetChild(8).gameObject.SetActive(false);//
            lava.SetActive(true);

            inRoom = true;
		}

        /* This attribute tells Utilla to call this method when a modded room is left */

        void OnModdedLeft(string modeName)
        {
            GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
            lava.SetActive(false);

            inRoom = false;
		}
	}
}
