using System;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.PlayerUtil
{
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
#if !UNITY_EDITOR
        public RagdollOnCollide(IntPtr ptr) : base(ptr) { }
#endif
    }
}