using UnityEngine;
using System;
using SLZ.VFX;
using TheLibraryElectric.Markers;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.Misc
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private bool activeState;
        public AudioSource audioSource;
        public GameObject[] excludedObjects;
        private Transform rigManager;
        private Blip blip;
        public void Disable()
        {
            activeState = false;
        }

        public void Enable()
        {
            activeState = true;
        }

        private void Start()
        {
            rigManager = GameObject.Find("[RigManager (Blank)]")?.transform;
            ModConsole.Msg($"Rigmanager is {rigManager.gameObject.name}", 1);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (activeState == true)
            {
                // Check if the colliding GameObject is not a child of the excluded object
                if (!collision.transform.IsChildOf(rigManager) && collision.gameObject.layer != 13 && !IsObjectExcluded(collision.gameObject) && !collision.gameObject.GetComponent<DoNotDestroy>())
                {
                    var rb = collision.transform.GetComponentInParent<Rigidbody>();
                    if (rb != null)
                    {
                        blip = rb.transform.GetComponent<Blip>();
                    }
                    if (blip != null)
                    {
                        blip.CallSpawnEffect();
                    }
                    audioSource.Play();
                    // Destroy the colliding GameObject
                    ModConsole.Msg($"Destroying {collision.gameObject.name}", 1);
                    Destroy(collision.gameObject);
                }
            }
        }
#if !UNITY_EDITOR
        public DestroyOnCollision(IntPtr ptr) : base(ptr) { }
#endif
        private bool IsObjectExcluded(GameObject obj)
        {
            foreach (var excludedObject in excludedObjects)
            {
                if (obj == excludedObject)
                {
                    ModConsole.Msg($"Ignoring {excludedObject}", 1);
                    return true;
                }
            }
            return false;
        }
    }

}