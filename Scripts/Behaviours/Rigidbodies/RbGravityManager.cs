using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Rigidbodies/Gravity Manager")]
#endif
    public class RbGravityManager : MonoBehaviour
    {
        public Rigidbody thisRb;
        public Vector3 GravityAmount { get; set; }
        [NonSerialized]
        private readonly Action<RbGravityManager> _onDestroyed = null;

        private void Start()
        {
            thisRb = GetComponent<Rigidbody>(); // Get the Rigidbody component
            if (thisRb != null)
            {
                thisRb.useGravity = false; // Disable gravity so the scene gravity doesn't interfere
            }
        }

        private void FixedUpdate()
        {
            if (thisRb != null)
            {
                thisRb.AddForce(GravityAmount * thisRb.mass, ForceMode.Force); // Add the gravity force
            }
        }
        private void OnDestroy()
        {
            _onDestroyed?.Invoke(this);
        }
        
#if MELONLOADER
        public RbGravityManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}