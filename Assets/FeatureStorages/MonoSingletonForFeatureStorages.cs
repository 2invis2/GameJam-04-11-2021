using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.FeatureStorages
{

    public class MonoSingletonForFeatureStorages : PseudoSingletonMonoBehaviour<MonoSingletonForFeatureStorages>
    {
        public FeatureStorage fsMain = FeatureStorageMain.Instance;
        public FeatureStorage fsBoss = FeatureStorageBoss.Instance;
        public FeatureStorage fsEnemy = FeatureStorageEnemy.Instance;
        public FeatureStorage fsEnv = FeatureStorageEnv.Instance;
        public FeatureStorage fsProjectile = FeatureStorageProjectile.Instance;
        public FeatureStorage fsRooms = FeatureStorageRooms.Instance;

        private void Start()
        {
            Debug.Log(
                "fsMain exists: " + (fsMain != null) + "\n" +
                (fsMain != null ? "feature count: " + fsMain.Features.ToList().Count + "\n" : "") +
                "fsBoss exists: " + (fsBoss != null) + "\n" +
                "fsEnemy exists: " + (fsEnemy != null) + "\n" +
                "fsEnv exists: " + (fsEnv != null) + "\n" +
                "fsProjectile exists: " + (fsProjectile != null) + "\n" +
                "fsRooms exists: " + (fsRooms != null) + "\n"
                );
        }
    }
}
