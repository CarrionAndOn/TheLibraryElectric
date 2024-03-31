using System;
using UnityEngine;
using UltEvents;

namespace TheLibraryElectric.Misc
{
    public class InvokeWhenCounter : MonoBehaviour
    {
        public float counter;
        public float countersNeeded = 5;
        public UltEvent onCounterHit;
        public void Add(float value)
        {
            counter += value;
            if (counter == countersNeeded)
            {
                onCounterHit.Invoke();
                counter = 0;
            }
        }
        public void Subtract(float value)
        {
            counter -= value;
        }
        public float GetCounter()
        {
            return counter;
        }
#if !UNITY_EDITOR
        public InvokeWhenCounter(IntPtr ptr) : base(ptr) { }
#endif
    }
}