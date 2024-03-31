using System;
using SLZ.Interaction;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Hand Holder")]
#endif
    public class HandHolder : MonoBehaviour
    {
        public Hand Variable { get; set; }
        
#if MELONLOADER
        public HandHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
