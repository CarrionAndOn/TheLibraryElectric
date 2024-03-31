using UnityEngine;
using System;

namespace TheLibraryElectric.Misc
{
    public class RealtimeAnalogClock : MonoBehaviour
    {
        public enum RotationEnum
        {
            XAxis, YAxis, ZAxis
        };
        public bool flip;
        public RotationEnum rotationAxis;
        public Transform hoursHand;
        public Transform minutesHand;
        public Transform secondsHand;
        private const float HoursToDegrees = 360f / 12f;
        private const float MinutesToDegrees = 360f / 60f;
        private const float SecondsToDegrees = 360f / 60f;
        private int _hours;
        private int _minutes;
        private int _seconds;
        
        private void Update()
        {
            _hours = DateTime.Now.Hour;
            _minutes = DateTime.Now.Minute;
            _seconds = DateTime.Now.Second;
            if (!flip)
            {
                switch (rotationAxis)
                {
                    case RotationEnum.XAxis:
                        hoursHand.localRotation = Quaternion.Euler(-HoursToDegrees * _hours, 0f, 0f);
                        minutesHand.localRotation = Quaternion.Euler(-MinutesToDegrees * _minutes, 0f, 0f);
                        secondsHand.localRotation = Quaternion.Euler(-SecondsToDegrees * _seconds, 0f, 0f);
                        break;
                    case RotationEnum.YAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, -HoursToDegrees * _hours, 0f);
                        minutesHand.localRotation = Quaternion.Euler(0f, -MinutesToDegrees * _minutes, 0f);
                        secondsHand.localRotation = Quaternion.Euler(0f, -SecondsToDegrees * _seconds, 0f);
                        break;
                    case RotationEnum.ZAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, 0f, -HoursToDegrees * _hours);
                        minutesHand.localRotation = Quaternion.Euler(0f, 0f, -MinutesToDegrees * _minutes);
                        secondsHand.localRotation = Quaternion.Euler(0f, 0f, -SecondsToDegrees * _seconds);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (rotationAxis)
                {
                    case RotationEnum.XAxis:
                        hoursHand.localRotation = Quaternion.Euler(HoursToDegrees * _hours, 0f, 0f);
                        minutesHand.localRotation = Quaternion.Euler(MinutesToDegrees * _minutes, 0f, 0f);
                        secondsHand.localRotation = Quaternion.Euler(SecondsToDegrees * _seconds, 0f, 0f);
                        break;
                    case RotationEnum.YAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, HoursToDegrees * _hours, 0f);
                        minutesHand.localRotation = Quaternion.Euler(0f, MinutesToDegrees * _minutes, 0f);
                        secondsHand.localRotation = Quaternion.Euler(0f, SecondsToDegrees * _seconds, 0f);
                        break;
                    case RotationEnum.ZAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, 0f, HoursToDegrees * _hours);
                        minutesHand.localRotation = Quaternion.Euler(0f, 0f, MinutesToDegrees * _minutes);
                        secondsHand.localRotation = Quaternion.Euler(0f, 0f, SecondsToDegrees * _seconds);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
#if !UNITY_EDITOR
        public RealtimeAnalogClock(IntPtr ptr) : base(ptr) { }
#endif
    }
}