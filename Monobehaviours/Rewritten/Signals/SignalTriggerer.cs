using System;
using UnityEngine;
using WeatherElectric.TheLibraryElectric.Melon;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace WeatherElectric.TheLibraryElectric.Behaviours.Signals
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Signals/Signal Triggerer")]
#endif
    public class SignalTriggerer : MonoBehaviour
    {
        public string activationKey;
        public void Start()
        {
            ModConsole.Msg($"SignalTriggerer spawned, key is {activationKey}", 1);
        }
#if MELONLOADER
        public SignalTriggerer(IntPtr ptr) : base(ptr) { }
#endif
    }
}