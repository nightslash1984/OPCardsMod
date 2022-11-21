using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace OPCardsMod.Cards
{
    class Laser : CustomCard
    {
        internal static CardCategory category = CustomCardCategories.instance.CardCategory("Laser");

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = new CardCategory[] { Laser.category };
            cardInfo.blacklistedCategories = new CardCategory[] { BFG.category };

            gun.gravity = 0f;
            gun.projectileSpeed = 150f;
            gun.reloadTime = 0.003f;
            gun.attackSpeed = 100f;
            gun.damage = 0.01f;
            gun.reloadTimeAdd = 0.25f;

            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{OPCardsMod.ModInitials}][Card]{GetTitle()} has been setup");
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
            return "Laser";
        }
        protected override string GetDescription()
        {
            return "Shoots through walls";
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
                    stat = "Shoot through walls",
                    amount = "",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Bullet speed",
                    amount = "x10",
                    simepleAmount= CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Damage",
                    amount = "+25%",
                    simepleAmount= CardInfoStat.SimpleAmount.notAssigned
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
