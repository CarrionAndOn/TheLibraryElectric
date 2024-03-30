using SLZ.Marrow.Pool;
using UnityEngine;
using System;

namespace TheLibraryElectric.Marrow
{
    public class DespawnPooledObject : MonoBehaviour
    {
        private GameObject _self;
        private AssetPoolee _assetPoolee;
        private void Start()
        {
            _self = gameObject;
            _assetPoolee = gameObject.GetComponent<AssetPoolee>();
        }

        public void Despawn()
        {
            if (_assetPoolee != null)
            {
                _self.SetActive(false);
                _assetPoolee.Despawn();
            }
        }
#if !UNITY_EDITOR
        public DespawnPooledObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}