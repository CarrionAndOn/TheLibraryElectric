using UnityEngine;
using System;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.Misc
{
    public class TimescaleController : MonoBehaviour
    {
        public float incrementValue = 0.5f;
        private float timeScale = 1.0f;
        public void ScaleTime()
        {
            if (timeScale >= 0.1f)
            {
                Time.timeScale = timeScale;
            }
            else
            {
                ModConsole.Msg("Scale cannot be negative!", 1);
            }
        }
        private void FixedUpdate()
        {
            ScaleTime();
        }
        public void IncreaseTimeScale()
        {
            var currentTimeScale = timeScale;
            timeScale = currentTimeScale + incrementValue;
            ModConsole.Msg($"Increasing timeScale by {incrementValue}, now {timeScale}", 1);
        }
        public void DecreaseTimeScale()
        {
            var currentTimeScale = timeScale;
            var newTimeScale = currentTimeScale - incrementValue;
            if (currentTimeScale >= 0.1f)
            {
                timeScale = newTimeScale;
                ModConsole.Msg($"Decreasing timeScale by {incrementValue}, now {newTimeScale}", 1);
            }
            else
            {
                ModConsole.Msg("Scale cannot be negative!", 1);
            }
        }
        private void OnDestroy()
        {
            Time.timeScale = 1.0f;
        }
#if !UNITY_EDITOR
        public TimescaleController(IntPtr ptr) : base(ptr) { }
#endif
    }
}