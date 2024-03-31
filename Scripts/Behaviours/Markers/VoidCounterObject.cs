using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Markers
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Markers/Void Counter Object")]
#endif
    public class VoidCounterObject : ElectricBehaviour
    {
        public override string Comment => "This object will block projectiles thrown by corrupt nulls.";
        // some IDIOT misspelled this
        public bool disableDespsawnDelay;
        
#if MELONLOADER
        public VoidCounterObject(IntPtr ptr) : base(ptr) { }
#endif
    }
}