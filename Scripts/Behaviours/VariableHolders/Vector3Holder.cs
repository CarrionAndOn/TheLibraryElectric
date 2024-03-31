using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Vector3 Holder")]
#endif
    public class Vector3Holder : MonoBehaviour
    {
        public Vector3 Variable { get; set; }
        
#if MELONLOADER
        public Vector3Holder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
