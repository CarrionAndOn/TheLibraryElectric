using System;
using System.Collections.Generic;
using System.Linq;
using SLZ.Rig;
#if MELONLOADER
using UnhollowerBaseLib.Attributes;
#endif
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Rigidbodies/Gravity Chamber")]
#endif
    public class GravityChamber : MonoBehaviour
    {
        public List<RbGravityManager> inTriggerCol = new List<RbGravityManager>();
        public Vector3 GravityAmount { get; set;}
        public bool ignoreRigManager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponentInParent<Rigidbody>() != null && other.GetComponentInParent<Rigidbody>().GetComponent<RbGravityManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if(other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }
                other.GetComponentInParent<Rigidbody>().gameObject.AddComponent<RbGravityManager>().GravityAmount = GravityAmount; // Add the RBGravityManager component and set the gravity amount
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach(var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbGravityManager>() == null)
                        {
                            rb.gameObject.AddComponent<RbGravityManager>().GravityAmount = GravityAmount;

                        }
                    }
                }
                inTriggerCol.Add(other.GetComponentInParent<Rigidbody>().GetComponent<RbGravityManager>()); // Add the colliding GameObject to the list
            }
        }

        private void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (inTriggerCol.Contains(other.GetComponentInParent<Rigidbody>().GetComponent<RbGravityManager>())) // Check if the colliding GameObject is in the list
            {
                other.GetComponentInParent<Rigidbody>().useGravity = true; // Enable gravity
                Destroy(other.GetComponentInParent<Rigidbody>().GetComponent<RbGravityManager>()); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbGravityManager>() != null)
                        {
                            Destroy(rb.GetComponent<RbGravityManager>());

                        }
                    }
                }
                inTriggerCol.Remove(other.GetComponentInParent<Rigidbody>().GetComponent<RbGravityManager>()); // Remove the colliding GameObject from the list
            }

        }
        
#if MELONLOADER
        [HideFromIl2Cpp]
        private void OnGravityManagerDestroyed(RbGravityManager manager)
        {
            // Changed this to be an action so that the pooling fix wouldn't cause garbage collection errors
            inTriggerCol.Remove(manager); // Remove the colliding GameObject from the list
        }
#endif

        private void Update()
        {
            foreach (var rBGravityManager in inTriggerCol.Where(rBGravityManager => rBGravityManager != null))
            {
                rBGravityManager.GravityAmount = GravityAmount; // Get the RBGravityManager component & update the gravity amount
            }
        }
        
#if MELONLOADER
        public GravityChamber(IntPtr ptr) : base(ptr) { }
#endif
    }
}