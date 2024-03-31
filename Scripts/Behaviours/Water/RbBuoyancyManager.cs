using UnityEngine;
using System;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Water
{
#if UNITY_EDITOR
    [HideInInspector]
#endif
    public class RbBuoyancyManager : MonoBehaviour
    {
        public Rigidbody thisRb;
        public float buoyancyMultiplier; // Adjust this to control the buoyancy threshold.
        public float midpoint; // Adjust this to control the midpoint of the buoyancy threshold.
        public bool midpointSink; // Will masses at the midpoint sink or float?
        public bool dampening; // If dampening is enabled, drag will increase as the object sinks.
        public float dampeningAmount; // Dampening multiplier
        public bool isAnOverride; // If this is an override, it will not be destroyed or changed when entering water

        [NonSerialized]
        internal Action<RbBuoyancyManager> onDestroyed = null;

        private void Start()
        {
            thisRb = GetComponent<Rigidbody>(); // Get the Rigidbody component
            if (thisRb != null)
            {
                thisRb.useGravity = false; // Disable gravity so the scene gravity doesn't interfere
            }
        }

        private void OnDisable()
        {
            // When this object is disabled, re-enable gravity and destroy the script
            // Fixes pooling
            if (thisRb != null)
            {
                thisRb.useGravity = true;
            }

            if(!isAnOverride) Destroy(this); 
            else enabled = false;
        }

        private void OnDestroy()
        {
            onDestroyed?.Invoke(this);
        }

        private void FixedUpdate()
        {
            // Force the RB to have no gravity in case someone uses a grav chamber
            if (thisRb != null && thisRb.useGravity)
            {
                thisRb.useGravity = false;
            }
            // If mass is smaller than midpoint, float
            if (thisRb != null && thisRb.mass < midpoint)
            {
                var buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                thisRb.AddForce(Vector3.up * buoyantForce);
                if (dampening)
                { 
                    thisRb.velocity *= dampeningAmount;
                }
            }
            // If mass is bigger than midpoint, sink
            if (thisRb != null && thisRb.mass > midpoint)
            {
                var buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                thisRb.AddForce(Vector3.down * buoyantForce);
                if (dampening)
                { 
                    thisRb.velocity *= dampeningAmount;
                }
            }
            // If mass is the midpoint, go based off the settings
            if (thisRb != null && Math.Abs(thisRb.mass - midpoint) < 0.5f)
            {
                if (midpointSink)
                {
                    var buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                    thisRb.AddForce(Vector3.down * buoyantForce);
                    if (dampening)
                    { 
                        thisRb.velocity *= dampeningAmount;
                    }
                }
                if (!midpointSink)
                {
                    var buoyantForce = thisRb.mass + Physics.gravity.magnitude * buoyancyMultiplier;
                    thisRb.AddForce(Vector3.up * buoyantForce);
                    if (dampening)
                    { 
                            thisRb.velocity *= dampeningAmount;
                    }
                }
            }
        }
#if MELONLOADER
        public RbBuoyancyManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}