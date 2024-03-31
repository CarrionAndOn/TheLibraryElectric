using UnityEngine;
using TMPro;
using System;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.Misc
{
    public class UpdateTMP : MonoBehaviour
    {
        public TextMeshPro textMeshPro;
        public float startingValue = 1.0f;
        public float incrementAmount = 0.5f;
        public float minValue = 0.1f;

        private float currentValue;

        private void Start()
        {
            ModConsole.Msg($"Starting value is {startingValue}", 1);
            currentValue = startingValue;
            UpdateTextValue();
        }

        private void UpdateTextValue()
        {
            textMeshPro.text = currentValue.ToString("F1"); // Displaying with one decimal place
        }

        public void IncreaseValue()
        {
            currentValue += incrementAmount;
            ModConsole.Msg($"Increasing value by {incrementAmount}, now {currentValue}", 1);
            UpdateTextValue();
        }
        public void DecreaseValue()
        {
            currentValue -= incrementAmount;
            ModConsole.Msg($"Decreasing value by {incrementAmount}, now {currentValue}", 1);
            if (currentValue < 0.1f)
            {
                ModConsole.Msg("Value should not be lower than 0.1!", 1);
                currentValue = minValue;
            }
            UpdateTextValue();
        }
#if !UNITY_EDITOR
        public UpdateTMP(IntPtr ptr) : base(ptr) { }
#endif
    }
}