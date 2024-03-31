using System;
using SLZ.Rig;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Behaviours/Player Util/Ragdoll Zone")]
#endif
    public class RagdollZone : MonoBehaviour
    {
        public float delayBeforeUnragdoll = 2f;
        private RigManager _rigManager;

        private void OnTriggerEnter(Collider other)
        {
            _rigManager = other.GetComponentInParent<RigManager>();
            if (_rigManager != null)
            {
                _rigManager.physicsRig.RagdollRig();
                Invoke(nameof(Unragdoll), delayBeforeUnragdoll);
            }
        }
        
        private void Unragdoll()
        {
            _rigManager.physicsRig.UnRagdollRig();
        }
        
#if MELONLOADER
        public RagdollZone(IntPtr ptr) : base(ptr) { }
#endif
    }
}