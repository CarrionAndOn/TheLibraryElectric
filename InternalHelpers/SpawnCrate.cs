using System;
using BoneLib.Nullables;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using UnityEngine;
using SLZ.Marrow.Warehouse;

namespace TheLibraryElectric.InternalHelpers
{
    public static class SpawnCrate
    {
        public static void Spawn(Spawnable spawnable, Vector3 position, Quaternion rotation, bool ignorePolicy = false, Action<GameObject> callback = null)
        {
            AssetSpawner.Register(spawnable);
            AssetSpawner.Spawn(spawnable, position, rotation, new BoxedNullable<Vector3>(null), ignorePolicy, new BoxedNullable<int>(null), (Action<GameObject>)SpawnAction);
            return;

            void SpawnAction(GameObject go)
            {
                callback?.Invoke(go);
            }
        }
        
        public static void Spawn(SpawnableCrateReference spawnableCrateReference, Vector3 position, Quaternion rotation, bool ignorePolicy = false, Action<GameObject> callback = null)
        {
            Spawnable spawnable = new Spawnable()
            {
                crateRef = spawnableCrateReference
            };
            AssetSpawner.Register(spawnable);
            AssetSpawner.Spawn(spawnable, position, rotation, new BoxedNullable<Vector3>(null), ignorePolicy, new BoxedNullable<int>(null), (Action<GameObject>)SpawnAction);
            return;

            void SpawnAction(GameObject go)
            {
                callback?.Invoke(go);
            }
        }
        
        public static void Spawn(Barcode barcode, Vector3 position, Quaternion rotation, bool ignorePolicy = false, Action<GameObject> callback = null)
        {
            var crateRef = new SpawnableCrateReference(barcode);
            var spawnable = new Spawnable
            {
                crateRef = crateRef
            };
            AssetSpawner.Register(spawnable);
            AssetSpawner.Spawn(spawnable, position, rotation, new BoxedNullable<Vector3>(null), ignorePolicy, new BoxedNullable<int>(null), (Action<GameObject>)SpawnAction);
            return;

            void SpawnAction(GameObject go)
            {
                callback?.Invoke(go);
            }
        }
    }
}