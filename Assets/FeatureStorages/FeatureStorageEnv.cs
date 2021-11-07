using System.Collections.Generic;
using MurphyInc.Core.Model;

namespace Assets.Scripts.FeatureStorages
{
    public sealed class FeatureStorageEnv
    {
        private static readonly FeatureStorage instance;

        static FeatureStorageEnv()
        {
            instance = FeatureStorageMain.Instance;            

            instance.AddRange(_features);
        }

        private FeatureStorageEnv() { }

        public static FeatureStorage Instance => instance;
        public static ActionFeature GetByName(string name) => instance.GetByName(name);

        public static readonly ActionFeature SlidingTables = new ActionFeature(name: nameof(SlidingTables), description: "Столы скользят по полу", isEnable: false);
        public static readonly ActionFeature ConcreteChairs = new ActionFeature(name: nameof(ConcreteChairs), description: "Стулья из бетона", isEnable: false);
        public static readonly ActionFeature SlidingToilets = new ActionFeature(name: nameof(SlidingToilets), description: "Незакрепленные унитазы", isEnable: false);
        public static readonly ActionFeature LesserFOV = new ActionFeature(name: nameof(LesserFOV), description: "Плохая видимость", isEnable: false);
        public static readonly ActionFeature BiggerFOV = new ActionFeature(name: nameof(BiggerFOV), description: "Хорошая видимость", isEnable: false);
        public static readonly ActionFeature QuickDoor = new ActionFeature(name: nameof(QuickDoor), description: "Двери открываются быстрее", isEnable: false);
        public static readonly ActionFeature AllDoorIsOpen = new ActionFeature(name: nameof(AllDoorIsOpen), description: "Все двери открыты", isEnable: false);
        public static readonly ActionFeature LeakyFloor  = new ActionFeature(name: nameof(LeakyFloor), description: "Дырявый пол", isEnable: false);
        public static readonly ActionFeature BouncingProjectiles = new ActionFeature(name: nameof(BouncingProjectiles), description: "Отскакивающие снаряды", isEnable: false);

        public static IEnumerable<ActionFeature> Features => _features;

        private static ActionFeature[] _features =
            new ActionFeature[]
            {
                SlidingTables,
                ConcreteChairs,
                SlidingToilets,
                LesserFOV,
                BiggerFOV,
                QuickDoor,
                AllDoorIsOpen,
                LeakyFloor,
                BouncingProjectiles
            };
    }
}