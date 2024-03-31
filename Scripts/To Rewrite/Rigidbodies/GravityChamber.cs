using System;
using System.Collections.Generic;
using SLZ.Rig;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
    public class GravityChamber : MonoBehaviour
    {
        public List<RBGravityManager> inTriggerCol = new List<RBGravityManager>();
        public Vector3 gravityAmount;
        public bool ignoreRigManager;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponentInParent<Rigidbody>() != null && other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if(other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }
                other.GetComponentInParent<Rigidbody>().gameObject.AddComponent<RBGravityManager>().gravityAmount = gravityAmount; // Add the RBGravityManager component and set the gravity amount
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach(var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RBGravityManager>() == null)
                        {
                            rb.gameObject.AddComponent<RBGravityManager>().gravityAmount = gravityAmount;

                        }
                    }
                }
                inTriggerCol.Add(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Add the colliding GameObject to the list
            }
        }

        private void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (inTriggerCol.Contains(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>())) // Check if the colliding GameObject is in the list
            {
                other.GetComponentInParent<Rigidbody>().useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = other.GetComponentInParent<Rigidbody>().GetComponentsInChildren<Rigidbody>();
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RBGravityManager>() != null)
                        {
                            UnityEngine.Object.Destroy(rb.GetComponent<RBGravityManager>());

                        }
                    }
                }
                inTriggerCol.Remove(other.GetComponentInParent<Rigidbody>().GetComponent<RBGravityManager>()); // Remove the colliding GameObject from the list
            }

        }
        
        [HideFromIl2Cpp]
        private void OnGravityManagerDestroyed(RBGravityManager manager)
        {
            // Changed this to be an action so that the pooling fix wouldn't cause garbage collection errors
            inTriggerCol.Remove(manager); // Remove the colliding GameObject from the list
        }

        private void Update()
        {
            foreach(var rBGravityManager in inTriggerCol) // Loop through the list
            {
                if (rBGravityManager != null)
                {
                    rBGravityManager.gravityAmount = gravityAmount; // Get the RBGravityManager component & update the gravity amount
                }
            }
        }
#if !UNITY_EDITOR
        public GravityChamber(IntPtr ptr) : base(ptr) { }
#endif
    }
}