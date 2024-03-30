using UnityEngine;
using System;
using System.Collections.Generic;
using UltEvents;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Signals
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Signals/Signal Receiver")]
#endif
    public class SignalReceiver : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
#endif
        public static readonly List<SignalReceiver> Receivers = new List<SignalReceiver>();
        
        public string activationKey;
        public UltEvent onSignalReceive;

        private void Awake()
        {
            Receivers.Add(this);
        }
        
        private void Start()
        {
            ModConsole.Msg($"Reciever spawned, key is {activationKey}", 1);
        }
        
        private void OnDestroy()
        {
            Receivers.Remove(this);
        }
        
#if MELONLOADER
        public SignalReceiver(IntPtr ptr) : base(ptr) { }
#endif
    }
}