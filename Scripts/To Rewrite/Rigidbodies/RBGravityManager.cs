using System;
using UnityEngine;

namespace TheLibraryElectric.Rigidbodies
{
    public class RBGravityManager : MonoBehaviour
    {
        public Rigidbody thisRb;
        public Vector3 gravityAmount;
        [NonSerialized]
        private Action<RBGravityManager> onDestroyed = null;
        public Vector3 GravityAmount
        {
            get { return gravityAmount; }
            set { gravityAmount = value; }
        }

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
                thisRb.AddForce(gravityAmount * thisRb.mass, ForceMode.Force); // Add the gravity force
            }
        }
        private void OnDestroy()
        {
            onDestroyed?.Invoke(this);
        }
#if !UNITY_EDITOR
        public RBGravityManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}