using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using OPCardsMod.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace OPCardsMod
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class OPCardsMod : BaseUnityPlugin
    {
        private const string ModId = "com.OPCards.Mod";
        private const string ModName = "OPCardsMod";
        public const string Version = "1.3.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "OPC";

        public static OPCardsMod instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<Sniper>();
            CustomCard.BuildCard<AssaultRifle>();
            CustomCard.BuildCard<GaussCannon>();
            CustomCard.BuildCard<Speed>();
            CustomCard.BuildCard<DoubleJump>();
            CustomCard.BuildCard<BFG>();
            CustomCard.BuildCard<Laser>();
            CustomCard.BuildCard<A10>();
            CustomCard.BuildCard<Medkit>();
            CustomCard.BuildCard<TheBenefit>();
        }
    }
}
