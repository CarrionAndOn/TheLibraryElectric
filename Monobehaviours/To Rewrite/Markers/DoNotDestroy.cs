using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    public class DoNotDestroy : MonoBehaviour
    {
#if !UNITY_EDITOR
        public DoNotDestroy(IntPtr ptr) : base(ptr) { }
#endif
    }
}