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
            characterStatModifiersModifier.health_mult = 3f;
            characterStatModifiersModifier.sizeMultiplier_mult = 0.5f;
        }
    }
}
