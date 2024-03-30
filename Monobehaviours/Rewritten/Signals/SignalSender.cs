using UnityEngine;
using System;
using System.Linq;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Signals
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Signals/Signal Sender")]
#endif
    public class SignalSender : ElectricBehaviour
    {
        public override string Comment => "Call 'Broadcast' on this script to trigger all receivers with the same key.";
        public string activationKey;
        public void Broadcast()
        {
            foreach (var signalReceiver in SignalReceiver.Receivers.Where(signalReceiver => signalReceiver.activationKey == activationKey))
            {
                signalReceiver.onSignalReceive.Invoke();
            }
        }
#if MELONLOADER
        public SignalSender(IntPtr ptr) : base(ptr) { }
#endif
    }
}