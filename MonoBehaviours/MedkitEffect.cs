using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPCardsMod.MonoBehaviours
{
    public class MedkitEffect : ReversibleEffect
    {
        public override void OnStart()
        {
            characterDataModifier.maxHealth_mult = 3f;
            characterDataModifier.health_mult = 5f;
        }
    }
}
