using System;
using SLZ.Rig;
using TheLibraryElectric.Melon;
using UnityEngine;

namespace TheLibraryElectric.Water
{
    public class HandMonitor : MonoBehaviour
    {
        public Vector3 handVelocity;
        public RigManager rigManager;
        public float minimumVelocity;
        public float velocityMultiplier;
        private Rigidbody handRb;

        private void Start()
        {
            handRb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            handVelocity = handRb.velocity - rigManager.physicsRig.m_chest.GetComponent<Rigidbody>().velocity;
            if (handVelocity.sqrMagnitude > minimumVelocity)
            {
                rigManager.physicsRig.m_head.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, handVelocity.sqrMagnitude * velocityMultiplier));
                ModConsole.Msg("Chest velocity: " + rigManager.physicsRig.m_chest.GetComponent<Rigidbody>().velocity + "e: " + handVelocity.sqrMagnitude * 1000, 1);
            }
        }
#if !UNITY_EDITOR
        public HandMonitor(IntPtr ptr) : base(ptr) { }
#endif
    }
}