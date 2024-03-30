using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    public class DoNotFreeze : MonoBehaviour
    {
#if !UNITY_EDITOR
        public DoNotFreeze(IntPtr ptr) : base(ptr) { }
#endif
    }
}