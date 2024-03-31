using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Water
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Water/Ignore Rigidbody")]
#endif
    public class IgnoreRigidbody : ElectricBehaviour
    {
        public override string Comment => "Any rigidbody with this script will be ignored by water zones.";

#if MELONLOADER
        public IgnoreRigidbody(IntPtr ptr) : base(ptr) { }
#endif
    }
}