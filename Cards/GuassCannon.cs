using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace OPCardsMod.Cards
{
    class GaussCannon : CustomCard
    {
        internal static CardCategory category = CustomCardCategories.instance.CardCategory("GuassCannon");
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            cardInfo.categories = new CardCategory[] { GaussCannon.category };
            cardInfo.blacklistedCategories = new CardCategory[] { Sniper.category, AssaultRifle.category, BFG.category, Laser.category };

            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{OPCardsMod.ModInitials}][Card]{GetTitle()} has been setup");

            gun.projectileSpeed = 6.0f;
            gun.damage = 5.0f;
            gun.ammo = -10;
            gun.attackSpeed = 0.25f;
            gun.reloadTimeAdd = 5.0f;
            gun.projectileSize = 2.0f;
            gun.bodyRecoil = 5.5f;
            gun.recoil = 3.5f;
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
            return "Guass Cannon";
        }
        protected override string GetDescription()
        {
            return "Extremely high powered cannon with long reload time";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "Massive amount of",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullet Speed",
                    amount = "Huge Amount of",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullet Size",
                    amount = "Double",
                    simepleAmount= CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "-10",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat() 
                {
                    positive = false,
                    stat = "Attack Speed",
                    amount = "-75%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Time",
                    amount = "+5s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return OPCardsMod.ModInitials;
        }
    }
}
