using System;
using UnityEngine;

namespace TheLibraryElectric.Markers
{
    public class VoidCounterObject : MonoBehaviour
    {
        // some IDIOT misspelled this
        public bool disableDespsawnDelay;
#if !UNITY_EDITOR
        public VoidCounterObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}