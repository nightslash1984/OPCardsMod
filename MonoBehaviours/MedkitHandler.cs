using UnityEngine;
using ModdingUtils.MonoBehaviours;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using OPCardsMod.Cards;
using System.Collections;
using System.Numerics;
using ModsPlus;

namespace OPCardsMod.MonoBehaviours
{
    public class MedkitHandler : CardEffect
    {
        private MedkitEffect activeEffect = null;

        public override IEnumerator OnBlockCoroutine(BlockTrigger.BlockTriggerType trigger)
        {
            // exit if the effect is already active
            if (activeEffect != null) yield break;

            // apply the effect
            activeEffect = player.gameObject.AddComponent<MedkitEffect>();

            // remove the effect after 5 seconds
            yield return new WaitForSeconds(5f);
            Destroy(activeEffect);
            activeEffect = null;
        }
    }
}