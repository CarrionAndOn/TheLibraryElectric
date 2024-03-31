using UnityEngine;
using System;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Environment
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Environment/Time Cycle Handler")]
#endif
    public class TimeCycleHandler : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Light")]
		[Tooltip("The directional light that will be rotated.")]
        public Light sun;
		[Header("Light Settings")]
		[Tooltip("What should the light's rotation on the Y axis be?")]
        public float yAxis;
		[Tooltip("What should the light's rotation on the Z axis be?")]
        public float zAxis;
	    [Tooltip("What should the light's intensity be at night?")]
	    public float nightLightIntensity = 0.001f;
	    [Tooltip("What should the light's intensity be at day?")]
	    public float dayLightIntensity = 1.0f;
		[Tooltip("What should the light's color be at day?")]
		public Color dayColor = Color.white;
		[Tooltip("What should the light's color be at night?")]
        public Color nightColor = Color.black;
        [Tooltip("The reflection probe(s) to change the intensity of.")]
        public ReflectionProbe[] reflectionProbes;
        [Header("Reflection Probe Settings")]
        [Tooltip("What should the reflection probe's intensity be at night?")]
        public float nightIntensity = 0.4f;
        [Tooltip("What should the reflection probe's intensity be at day?")]
        public float dayIntensity = 1.0f;
        [Header("Time Settings")] 
        [Tooltip("What hour should the night start? 24 hour format")]
        public float nightStartHour = 19.0f;
	    [Tooltip("What hour should the night end? 24 hour format")]
        public float nightEndHour = 6.0f;
#else
        public Light sun;
        public float yAxis;
        public float zAxis;
        public float nightLightIntensity = 0.001f;
        public float dayLightIntensity = 1.0f;
        public Color dayColor = Color.white;
        public Color nightColor = Color.black;
        public ReflectionProbe[] reflectionProbes;
        public float nightIntensity = 0.4f;
        public float dayIntensity = 1.0f;
        public float nightStartHour = 19.0f;
        public float nightEndHour = 6.0f;
#endif

        private void Update()
        {
            var now = DateTime.Now;
            float hours = now.Hour;
            float minutes = now.Minute;
            float seconds = now.Second;
            var totalSeconds = hours * 3600 + minutes * 60 + seconds;
            var angle = 90 - (totalSeconds / 86400) * 360;
            sun.transform.rotation = Quaternion.Euler(-angle, yAxis, zAxis);
            foreach (var reflectionProbe in reflectionProbes)
            {
                reflectionProbe.intensity = CalculateIntensity(hours, false);
            }
            sun.intensity = CalculateIntensity(hours, true);
            sun.color = CalculateColor(hours);
        }
        
        private float CalculateIntensity(float hours, bool light)
        {
            if (light)
            {
                if (hours >= nightStartHour || hours < nightEndHour)
                {
                    return nightLightIntensity;
                }

                return dayLightIntensity;
            }

            if (hours >= nightStartHour || hours < nightEndHour)
            {
                return nightIntensity;
            }

            return dayIntensity;
        }

        private Color CalculateColor(float hours)
        {
            if (hours >= nightStartHour || hours < nightEndHour)
            {
                return nightColor;
            }

            return dayColor;
        }
        
#if MELONLOADER
        public TimeCycleHandler(IntPtr ptr) : base(ptr) { }
#endif
    }
}