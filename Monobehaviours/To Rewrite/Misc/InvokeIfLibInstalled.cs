using System;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class InvokeIfLibInstalled : MonoBehaviour
    {
        public UltEvent ifInstalled;
        public void Awake()
        {
            ifInstalled.Invoke();
        }
#if !UNITY_EDITOR
        public InvokeIfLibInstalled(IntPtr ptr) : base(ptr) { }
#endif
    }
}
