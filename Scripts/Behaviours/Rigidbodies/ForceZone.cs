using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Rigidbodies
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Rigidbodies/Force Zone")]
    [RequireComponent(typeof(Collider))]
#endif
    public class ForceZone : MonoBehaviour
    {
        public List<Rigidbody> inTriggerRbs = new List<Rigidbody>();
        public Vector3 ForceAmount { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                inTriggerRbs.Add(other.attachedRigidbody);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null && inTriggerRbs.Contains(other.attachedRigidbody))
            {
                inTriggerRbs.Remove(other.attachedRigidbody);
            }
        }

        private void Update()
        {
            foreach (var rb in inTriggerRbs)
            {
                rb.AddForce(ForceAmount, ForceMode.Force);
            }
        }
        
#if MELONLOADER
        public ForceZone(IntPtr ptr) : base(ptr) { }
#endif
    }
}
