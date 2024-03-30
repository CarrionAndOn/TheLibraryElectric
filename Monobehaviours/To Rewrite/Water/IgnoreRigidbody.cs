using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
    public class IgnoreRigidbody : MonoBehaviour
    {
#if !UNITY_EDITOR
        public IgnoreRigidbody(IntPtr ptr) : base(ptr) { }
#endif
    }
}