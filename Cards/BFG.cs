using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using Photon.Pun;
using Sonigon;
using UnboundLib.Utils;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace OPCardsMod.Cards
{
	class BFG : CustomCard
	{
        internal static CardCategory category = CustomCardCategories.instance.CardCategory("BFG");

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
		{
            cardInfo.categories = new CardCategory[] { BFG.category };
            cardInfo.blacklistedCategories = new CardCategory[] { Sniper.category, AssaultRifle.category, GaussCannon.category, Laser.category, A10.category};
			cardInfo.allowMultiple = false;

            var BFGgun = CardManager.cards.Values
			  .Where((card) => card.cardInfo.cardName.ToLower() == "Homing".ToLower())
			  .Select((card) => card.cardInfo.gameObject.GetComponent<Gun>())
			  .FirstOrDefault();

            gun.objectsToSpawn = BFGgun.objectsToSpawn;

			gun.projectileColor = Color.green;

			gun.gravity = 0f;
			gun.projectileSpeed = 0.40f;
			gun.projectileSize = 1.15f;
			gun.damage = 50f;
			gun.ammo = -1000;
			gun.reloadTime = 35.0f;
			gun.destroyBulletAfter = 100000f;
			statModifiers.movementSpeed = 0.75f;
		}
		public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
		{
			//Edits values on player when card is selected
			UnityEngine.Debug.Log($"[{OPCardsMod.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
		}
		public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
		{
			//Run when the card is removed from the player
			UnityEngine.Debug.Log($"[{OPCardsMod.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
		}

		protected override string GetTitle()
		{
			return "BFG";
		}
		protected override string GetDescription()
		{
			return "BIG FUCKING GUN";
		}
		protected override GameObject GetCardArt()
		{
			return null;
		}
		protected override CardInfo.Rarity GetRarity()
		{
			return CardInfo.Rarity.Rare;
		}
		protected override CardInfoStat[] GetStats()
		{
			return new CardInfoStat[]
			{
				new CardInfoStat()
				{
					positive = false,
					stat = "Bullet Speed",
					amount = "-90%",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				},
				new CardInfoStat()
				{
					positive = true,
					stat = "Damage",
					amount = "x50",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				},
				new CardInfoStat()
				{
					positive = false,
					stat = "Reload Time",
					amount = "30s",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				},
				new CardInfoStat()
				{
					positive = false,
					stat = "Ammo",
					amount = "-1000 (to 1)",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				},
				new CardInfoStat()
				{
					positive = true,
					stat = "Bullet Gravity",
					amount = "0",
					simepleAmount = CardInfoStat.SimpleAmount.notAssigned
				}
			};
		}
		protected override CardThemeColor.CardThemeColorType GetTheme()
		{
			return CardThemeColor.CardThemeColorType.FirepowerYellow;
		}
		public override string GetModName()
		{
			return OPCardsMod.ModInitials;
		}
	}

}
