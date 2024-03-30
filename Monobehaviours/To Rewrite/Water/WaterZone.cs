using System;
using System.Collections.Generic;
using SLZ;
using SLZ.Rig;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace TheLibraryElectric.Water
{
    public class WaterZone : MonoBehaviour
    {
        public List<RbBuoyancyManager> inTriggerCol = new List<RbBuoyancyManager>();
        public float buoyancyMultiplier = 1.0f; // Adjust this to control the buoyancy threshold.
        public float midpoint = 50.0f; // Adjust this to control the midpoint of the effect.
        public bool midpointSink = true; // Will masses at the midpoint sink or float?
        public bool dampening = true; // If dampening is enabled, drag will increase as the object sinks.
        public float dampeningAmount = 0.98f; // Dampening multiplier
        public bool ignoreRigManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            var colliderRigidbody = other.attachedRigidbody;
            RbBuoyancyManager managere = null;
            if(colliderRigidbody != null) managere = colliderRigidbody.GetComponent<RbBuoyancyManager>();
            if(managere != null && managere.isAnOverride)
            {
                managere.enabled = true;
                inTriggerCol.Add(managere); // Add the colliding GameObject to the list
                return;
            }
            if (colliderRigidbody != null && colliderRigidbody.GetComponent<RbBuoyancyManager>() == null) // Check if the colliding GameObject has a Rigidbody and doesn't have the RBGravityManager component
            {
                if (other.GetComponentInParent<RigManager>() != null && ignoreRigManager)
                {
                    return;
                }

                var themanager = colliderRigidbody.gameObject.AddComponent<RbBuoyancyManager>(); // Add the RBGravityManager component and set the gravity amount

                if(other.GetComponentInParent<IgnoreRigidbody>() != null)
                {
                    return;
                }
                
                themanager.dampening = dampening;
                themanager.buoyancyMultiplier = buoyancyMultiplier;
                themanager.midpoint = midpoint;
                themanager.dampeningAmount = dampeningAmount;
                themanager.midpointSink = midpointSink;
                themanager.onDestroyed = OnBuoyancyManagerDestroyed;
                Rigidbody[] childRbs = colliderRigidbody.GetComponentsInChildren<Rigidbody>(true);
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() == null)
                        {
                            var manager = rb.gameObject.AddComponent<RbBuoyancyManager>();
                            manager.buoyancyMultiplier = buoyancyMultiplier;
                            manager.dampening = dampening;
                            manager.midpoint = midpoint;
                            manager.dampeningAmount = dampeningAmount;
                            manager.midpointSink = midpointSink;
                        }
                    }
                }
                inTriggerCol.Add(themanager); // Add the colliding GameObject to the list
            }
        }

        private void OnTriggerExit(Collider other) // When the GameObject exits the trigger collider
        {
            if (other.isTrigger) return;
            var colliderRigidbody = other.attachedRigidbody;
            RbBuoyancyManager manager = null;

            if (colliderRigidbody != null)
                manager = colliderRigidbody.GetComponent<RbBuoyancyManager>();

            if (inTriggerCol.Contains(manager)) // Check if the colliding GameObject is in the list
            {
                if (manager.isAnOverride)
                {
                    manager.enabled = false;
                    manager.onDestroyed.Invoke(manager);
                    return;
                }
                colliderRigidbody.useGravity = true; // Enable gravity
                UnityEngine.Object.Destroy(manager); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = colliderRigidbody.GetComponentsInChildren<Rigidbody>(true);
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() != null)
                        {
                            UnityEngine.Object.Destroy(rb.GetComponent<RbBuoyancyManager>());
                        }
                    }
                }
            }

        }

        [HideFromIl2Cpp]
        private void OnBuoyancyManagerDestroyed(RbBuoyancyManager manager)
        {
            // Changed this to be an action so that the pooling fix wouldn't cause garbage collection errors
            inTriggerCol.Remove(manager); // Remove the colliding GameObject from the list
        }

        private void Update()
        {
            foreach(var rBBuoyancyManager in inTriggerCol) // Loop through the list
            {
                if (rBBuoyancyManager != null && !rBBuoyancyManager.isAnOverride)
                {
                    rBBuoyancyManager.buoyancyMultiplier = buoyancyMultiplier; // Get the RBGravityManager component & update the gravity amount
                    rBBuoyancyManager.dampening = dampening;
                    rBBuoyancyManager.midpoint = midpoint;
                    rBBuoyancyManager.dampeningAmount = dampeningAmount;
                    rBBuoyancyManager.midpointSink = midpointSink;
                }
            }
        }
#if !UNITY_EDITOR
        public WaterZone(IntPtr ptr) : base(ptr) { }
#endif
    }
}