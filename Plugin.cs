using System;
using BepInEx;
using UnityEngine;
using Utilla;

namespace bringbacklavaupdate
{

	
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{
			
			Utilla.Events.GameInitialized += OnGameInitialized;
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
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
            GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
            lava.SetActive(true);

            inRoom = true;
		}
       
        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
            GameObject lava = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_PrefabV");
            lava.SetActive(false);

            inRoom = false;
		}
	}
}
