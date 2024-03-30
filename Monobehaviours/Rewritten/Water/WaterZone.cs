using System;
using System.Collections.Generic;
using System.Linq;
using SLZ.Rig;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Water/Water Zone")]
#endif
    public class WaterZone : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
        public List<RbBuoyancyManager> inTriggerCol = new List<RbBuoyancyManager>();

        [Tooltip("The amount of buoyancy the water will apply to the Rigidbody.")]
        public float buoyancyMultiplier = 1.0f;
        [Tooltip("The point of mass where rigidbodies will start sinking")]
        public float midpoint = 50.0f;
        [Tooltip("Should the midpoint be a sink point?")]
        public bool midpointSink = true;
        [Tooltip("Should the water dampen the rigidbody's velocity?")]
        public bool dampening = true;
        [Tooltip("The amount of dampening the water will apply to the Rigidbody.")]
        public float dampeningAmount = 0.98f;
        [Tooltip("Should the water ignore the player?")]
        public bool ignoreRigManager;
#else
        public List<RbBuoyancyManager> inTriggerCol = new List<RbBuoyancyManager>();
        public float buoyancyMultiplier = 1.0f;
        public float midpoint = 50.0f;
        public bool midpointSink = true;
        public bool dampening = true;
        public float dampeningAmount = 0.98f;
        public bool ignoreRigManager;
#endif

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            var colliderRigidbody = other.attachedRigidbody;
            RbBuoyancyManager managere = null;
            if(colliderRigidbody != null) managere = colliderRigidbody.GetComponent<RbBuoyancyManager>();
            if(managere != null && managere.isAnOverride)
            {
                managere.enabled = true;
                inTriggerCol.Add(managere);
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
                if (manager != null && manager.isAnOverride)
                {
                    manager.enabled = false;
                    manager.onDestroyed.Invoke(manager);
                    return;
                }
                colliderRigidbody.useGravity = true; // Enable gravity
                Destroy(manager); // Destroy the RBGravityManager component
                Rigidbody[] childRbs = colliderRigidbody.GetComponentsInChildren<Rigidbody>(true);
                foreach (var rb in childRbs)
                {
                    if (rb.isKinematic)
                    {
                        if (rb.GetComponent<RbBuoyancyManager>() != null)
                        {
                            Destroy(rb.GetComponent<RbBuoyancyManager>());
                        }
                    }
                }
            }

        }

#if MELONLOADER
        [HideFromIl2Cpp]
        private void OnBuoyancyManagerDestroyed(RbBuoyancyManager manager)
        {
            // Changed this to be an action so that the pooling fix wouldn't cause garbage collection errors
            inTriggerCol.Remove(manager); // Remove the colliding GameObject from the list
        }
#endif

        private void Update()
        {
            foreach (var rBBuoyancyManager in inTriggerCol.Where(rBBuoyancyManager => rBBuoyancyManager != null && !rBBuoyancyManager.isAnOverride))
            {
                rBBuoyancyManager.buoyancyMultiplier = buoyancyMultiplier; // Get the RBGravityManager component & update the gravity amount
                rBBuoyancyManager.dampening = dampening;
                rBBuoyancyManager.midpoint = midpoint;
                rBBuoyancyManager.dampeningAmount = dampeningAmount;
                rBBuoyancyManager.midpointSink = midpointSink;
            }
        }
        
#if MELONLOADER
        public WaterZone(IntPtr ptr) : base(ptr) { }
#endif
    }
}