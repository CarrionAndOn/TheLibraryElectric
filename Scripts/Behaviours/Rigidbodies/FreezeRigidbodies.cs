using UnityEngine;
using System;
using BoneLib;
using WeatherElectric.TheLibraryElectric.Behaviours.Markers;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Rigidbodies/Freeze Rigidbodies")]
#endif
    public class FreezeRigidbodies : MonoBehaviour
    {
        private GameObject _rigManager;
        
        private void Start()
        {
#if MELONLOADER
            var rm = Player.rigManager.gameObject;
#else
            var rm = GameObject.Find("[RigManager (Blank)]");
#endif
            ModConsole.Msg("Got rigmanager", 1);
            _rigManager = rm;
            Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
            ModConsole.Msg("Got rigidbodies", 1);
            foreach (var rb in allRigidbodies)
            {
                ModConsole.Msg("Giving existing kinematic RBs DoNotFreeze", 1);
                // Check if the GameObject has the DoNotFreeze component
                if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                {
                    continue; // Skip this if it already DoNotFreeze
                }
                if (!rb.transform.IsChildOf(_rigManager.transform) && rb.isKinematic)
                {
                    rb.gameObject.AddComponent<DoNotFreeze>();
                }
            }
        }
        
        public void Freeze()
        {
            if (_rigManager != null)
            {
                ModConsole.Msg("Getting rigidbodies", 1);
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
                foreach (var rb in allRigidbodies)
                {
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        ModConsole.Msg($"{rb.gameObject.name} has DoNotFreeze, skipping", 1);
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if (!rb.transform.IsChildOf(_rigManager.transform))
                    {
                        ModConsole.Msg("Froze all RBs", 1);
                        rb.isKinematic = true;
                    }
                }
            }
            else
            {
                ModConsole.Msg("Somehow, the rigmanager is null!");
            }
        }
        
        public void Unfreeze()
        {
            if (_rigManager != null)
            {
                ModConsole.Msg("Getting all RBs", 1);
                Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
                foreach (var rb in allRigidbodies)
                {
                    // Check if the GameObject has the DoNotFreeze component
                    if (rb.gameObject.GetComponent<DoNotFreeze>() != null)
                    {
                        continue; // Skip freezing if the DoNotFreeze component is present
                    }
                    if (!rb.transform.IsChildOf(_rigManager.transform))
                    {
                        rb.isKinematic = false;
                    }
                }
            }
            else
            {
                ModConsole.Msg("Somehow, the rigmanager is null!", 1);
            }
        }

        private void OnDestroy()
        {
            Unfreeze();
        }
        
#if MELONLOADER
        public FreezeRigidbodies(IntPtr ptr) : base(ptr) { }
#endif
    }
}