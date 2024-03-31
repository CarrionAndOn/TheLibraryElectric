using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/Quaternion Holder")]
#endif
    public class QuaternionHolder : MonoBehaviour
    {
        public Quaternion Variable { get; set; }
#if MELONLOADER
        public QuaternionHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
