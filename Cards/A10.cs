﻿using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;

namespace OPCardsMod.Cards
{
    class A10 : CustomCard
    {
        internal static CardCategory category = CustomCardCategories.instance.CardCategory("A10");

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = new CardCategory[] { A10.category };
            cardInfo.blacklistedCategories = new CardCategory[] { Sniper.category, AssaultRifle.category, GaussCannon.category, Laser.category, BFG.category};


            var A10Gun = CardManager.cards.Values
              .Where((card) => card.cardInfo.cardName.ToLower() == "Explosive bullet".ToLower())
              .Select((card) => card.cardInfo.gameObject.GetComponent<Gun>())
              .FirstOrDefault();

            gun.objectsToSpawn = A10Gun.objectsToSpawn;
            cardInfo.allowMultiple = false;

            gun.attackSpeed = 0.1f;
            gun.damage = 0.1f;
            gun.ammo = 100;
            gun.reloadTime = 15f;
            gun.projectileSpeed = 10f;
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
            return "A10";
        }
        protected override string GetDescription()
        {
            return "Bullets fly at the speed of sound and explode";
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
                    positive = true,
                    stat = "Attack Speed",
                    amount = "+90%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Damage",
                    amount = "-90%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+100",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "reload time",
                    amount = "15s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bulleet Speed",
                    amount = "10x",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return OPCardsMod.ModInitials;
        }
    }
}
