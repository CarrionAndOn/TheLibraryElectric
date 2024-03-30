using System;
using UnityEngine;
using SLZ.Rig;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.Water
{
    public class SwimmingController : MonoBehaviour
    {
        public RigManager rigManager;
        public float minimumVelocity = 10f;
        public float velocityMultiplier = 100f;

        private void OnTriggerEnter(Collider other)
        {
            rigManager = other.GetComponentInParent<RigManager>();
            if (rigManager != null)
            {
                ModConsole.Msg("SwimmingController: RigManager found!", 1);
                if (rigManager.physicsRig.leftHand.GetComponent<HandMonitor>() == null)
                {
                    var handMonitor = rigManager.physicsRig.leftHand.gameObject.AddComponent<HandMonitor>();
                    handMonitor.rigManager = rigManager;
                    handMonitor.minimumVelocity = minimumVelocity;

                }
                if (rigManager.physicsRig.rightHand.GetComponent<HandMonitor>() == null)
                {
                    var handMonitor = rigManager.physicsRig.rightHand.gameObject.AddComponent<HandMonitor>();
                    handMonitor.rigManager = rigManager;
                    handMonitor.minimumVelocity = minimumVelocity;
                    handMonitor.velocityMultiplier = velocityMultiplier;

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            rigManager = other.GetComponentInParent<RigManager>();
            if (rigManager != null)
            {
                if (rigManager.physicsRig.leftHand.GetComponent<HandMonitor>() != null)
                {
                    Destroy(rigManager.physicsRig.leftHand.GetComponent<HandMonitor>());
                }
            }
            if (rigManager != null)
            {
                if (rigManager.physicsRig.rightHand.GetComponent<HandMonitor>() != null)
                {
                    Destroy(rigManager.physicsRig.rightHand.GetComponent<HandMonitor>());
                }
            }
        }
#if !UNITY_EDITOR
        public SwimmingController(IntPtr ptr) : base(ptr) { }
#endif
    }
}