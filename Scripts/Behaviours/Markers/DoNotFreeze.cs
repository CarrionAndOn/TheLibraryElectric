using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Markers/Do Not Freeze")]
#endif
    public class DoNotFreeze : ElectricBehaviour
    {
        public override string Comment => "This object won't be frozen by FreezeRigidbodies.";
        
#if MELONLOADER
        public DoNotFreeze(IntPtr ptr) : base(ptr) { }
#endif
    }
}