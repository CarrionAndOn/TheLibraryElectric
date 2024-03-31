using System;
using TMPro;
using UnityEngine;

namespace TheLibraryElectric.Vehicles
{
    public class RbSpeedMeter : MonoBehaviour
    {
        public Rigidbody targetRigidbody;
        public TextMeshPro speedText;
        public string speedFormat = "Speed: {0:0.00} m/s";

        private void FixedUpdate()
        {
            if (targetRigidbody != null)
            {
                var speed = targetRigidbody.velocity.magnitude;
                speedText.text = string.Format(speedFormat, speed);
            }
        }
#if !UNITY_EDITOR
        public RbSpeedMeter(IntPtr ptr) : base(ptr) { }
#endif
    }
}