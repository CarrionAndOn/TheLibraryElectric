using System;
using SLZ.Marrow.Data;
using SLZ.Marrow.Warehouse;
using TheLibraryElectric.InternalHelpers;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Marrow
{
    public class CoolerSpawnablePlacer : MonoBehaviour
    {
        public SpawnableCrateReference spawnableCrateReference;
        public SpawnPolicyData spawnPolicy;
        public bool manualMode;
        public bool ignorePolicy;
        public bool IgnorePolicy
        {
            get => ignorePolicy;
            set => ignorePolicy = value;
        }
        public UltEvent onPlaceEvent;

        private void Start()
        {
            if (!manualMode)
            {
                if (spawnPolicy == null)
                {
                    var spawnableCrate = new Spawnable()
                    {
                        crateRef = spawnableCrateReference
                    };
                    SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                    {
                
                    });
                }
                else
                {
                    var spawnableCrate = new Spawnable()
                    {
                        crateRef = spawnableCrateReference,
                        policyData = spawnPolicy
                    };
                    SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                    {
                
                    });
                }
                onPlaceEvent.Invoke();
            }
        }

        public void Spawn()
        {
            if (spawnPolicy == null)
            {
                var spawnableCrate = new Spawnable()
                {
                    crateRef = spawnableCrateReference
                };
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                {
                
                });
            }
            else
            {
                var spawnableCrate = new Spawnable()
                {
                    crateRef = spawnableCrateReference,
                    policyData = spawnPolicy
                };
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                {
                
                });
            }
            onPlaceEvent.Invoke();
        }
        
        public void SpawnWithForce(Vector3 force)
        {
            if (spawnPolicy == null)
            {
                var spawnableCrate = new Spawnable()
                {
                    crateRef = spawnableCrateReference
                };
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                {
                    go.GetComponent<Rigidbody>().AddRelativeForce(force);
                });
            }
            else
            {
                var spawnableCrate = new Spawnable()
                {
                    crateRef = spawnableCrateReference,
                    policyData = spawnPolicy
                };
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy, go =>
                {
                    go.GetComponent<Rigidbody>().AddRelativeForce(force);
                });
            }
            onPlaceEvent.Invoke();
        }
#if !UNITY_EDITOR
        public CoolerSpawnablePlacer(IntPtr ptr) : base(ptr) { }
#endif
    }
}