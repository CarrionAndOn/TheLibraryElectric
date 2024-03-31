using System;
using SLZ.Rig;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Behaviours/Player Util/Ragdoll On Collide")]
#endif
    public class RagdollOnCollide : MonoBehaviour
    {
        public float delayBeforeUnragdoll = 2f;
        private RigManager _rigManager;
        
        private void OnCollisionEnter()
        {
            var col = GetComponent<Collider>();
            _rigManager = col.GetComponentInParent<RigManager>();
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
        public RagdollOnCollide(IntPtr ptr) : base(ptr) { }
#endif
    }
}