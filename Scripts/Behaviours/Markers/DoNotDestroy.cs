using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Markers/Do Not Destroy")]
#endif
    public class DoNotDestroy : ElectricBehaviour
    {
        public override string Comment => "This object won't be destroyed by other scripts.";
        
#if MELONLOADER
        public DoNotDestroy(IntPtr ptr) : base(ptr) { }
#endif
    }
}