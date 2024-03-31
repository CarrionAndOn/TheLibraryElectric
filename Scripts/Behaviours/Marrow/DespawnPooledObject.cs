using SLZ.Marrow.Pool;
using UnityEngine;
using System;

namespace TheLibraryElectric.Marrow
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Marrow/Despawn Pooled Object")]
#endif
    public class DespawnPooledObject : MonoBehaviour
    {
        private AssetPoolee _assetPoolee;
        private void Start()
        {
            _assetPoolee = gameObject.GetComponent<AssetPoolee>();
        }

        public void Despawn()
        {
            if (_assetPoolee != null)
            {
                _assetPoolee.Despawn();
            }
        }
#if MELONLOADER
        public DespawnPooledObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}