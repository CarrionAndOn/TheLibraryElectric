using System;
using SLZ.Rig;
using UnityEngine;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Water
{
#if UNITY_EDITOR
    [HideInInspector]
#endif
    public class HandMonitor : MonoBehaviour
    {
        public Vector3 handVelocity;
        public RigManager rigManager;
        public float minimumVelocity;
        public float velocityMultiplier;
        private Rigidbody _handRb;

        private void Start()
        {
            _handRb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            handVelocity = _handRb.velocity - rigManager.physicsRig.m_chest.GetComponent<Rigidbody>().velocity;
            if (handVelocity.sqrMagnitude > minimumVelocity)
            {
                rigManager.physicsRig.m_head.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, handVelocity.sqrMagnitude * velocityMultiplier));
                ModConsole.Msg("Chest velocity: " + rigManager.physicsRig.m_chest.GetComponent<Rigidbody>().velocity + "e: " + handVelocity.sqrMagnitude * 1000, 1);
            }
        }
#if MELONLOADER
        public HandMonitor(IntPtr ptr) : base(ptr) { }
#endif
    }
}