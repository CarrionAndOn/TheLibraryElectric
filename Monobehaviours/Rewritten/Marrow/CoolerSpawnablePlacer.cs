using System;
using SLZ.Marrow.Data;
using SLZ.Marrow.Warehouse;
#if MELONLOADER
using TheLibraryElectric.InternalHelpers;
#endif
using UltEvents;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using SLZ.Marrow.Utilities;
#endif

namespace WeatherElectric.TheLibraryElectric.Behaviours.Marrow
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Marrow/Cooler Spawnable Placer")]
#endif
    public class CoolerSpawnablePlacer : MonoBehaviour
    {
        public SpawnableCrateReference spawnableCrateReference;
        public SpawnPolicyData spawnPolicy;
        public bool manualMode;
        public bool ignorePolicy;
        public UltEvent onPlaceEvent;
        
#if UNITY_EDITOR
        public static bool showPreviewMesh = true;
        public static bool showColliderBounds = true;
        private static Material voidMaterial = null;
#endif
        
#if MELONLOADER
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
                    SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy);
                }
                else
                {
                    var spawnableCrate = new Spawnable()
                    {
                        crateRef = spawnableCrateReference,
                        policyData = spawnPolicy
                    };
                    SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy);
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
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy);
            }
            else
            {
                var spawnableCrate = new Spawnable()
                {
                    crateRef = spawnableCrateReference,
                    policyData = spawnPolicy
                };
                SpawnCrate.Spawn(spawnableCrate, transform.position, Quaternion.identity, ignorePolicy);
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
#else
        private void Start()
        {
        
        }
        
        public void Spawn()
        {
        
        }
        
        public void SpawnWithForce(Vector3 force)
        {
        
        }
        
        private SpawnableCrateReference GetCrateReference()
        {
            if (AssetWarehouse.ready)
            {
                return spawnableCrateReference;
            }

            return null;
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawPreviewGizmo(CoolerSpawnablePlacer placer, GizmoType gizmoType)
        {
            if (!Application.isPlaying && placer.gameObject.scene != default)
            {
                if (voidMaterial == null)
                {
                    voidMaterial = AssetDatabase.LoadAssetAtPath<Material>("Packages/com.stresslevelzero.marrow.sdk/sdk/Editor/Assets/Materials/Void Glow.mat");
                }
                EditorPreviewMeshGizmo.Draw("PreviewMesh", placer.gameObject, placer.GetCrateReference(), voidMaterial, !showPreviewMesh, !showColliderBounds, true);
            }
        }
#endif
        
#if MELONLOADER
        public CoolerSpawnablePlacer(IntPtr ptr) : base(ptr) { }
#endif
    }
}