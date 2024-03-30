using System;
using UnityEngine;
using UltEvents;
using UnityEditor;

namespace TheLibraryElectric.Misc
{
    public class SimpleCounter : MonoBehaviour
    {
        public float counter { get; set; }
        public UltEvent onCounterHit;
        public void Add(float value)
        {
            counter += value;
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
        public SimpleCounter(IntPtr ptr) : base(ptr) { }
#endif
    }
}