using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Float Holder")]
#endif
    public class FloatHolder : MonoBehaviour
    {
        public float Variable { get; set; }
        
#if MELONLOADER
        public FloatHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
