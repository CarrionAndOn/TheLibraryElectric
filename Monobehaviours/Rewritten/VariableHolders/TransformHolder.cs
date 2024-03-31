using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Transform Holder")]
#endif
    public class TransformHolder : MonoBehaviour
    {
        public Transform Variable { get; set; }
        
#if MELONLOADER
        public TransformHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
