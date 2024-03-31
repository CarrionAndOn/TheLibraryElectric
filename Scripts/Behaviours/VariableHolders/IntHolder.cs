using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Int Holder")]
#endif
    public class IntHolder : MonoBehaviour
    {
        public int Variable { get; set; }
        
#if MELONLOADER
        public IntHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
