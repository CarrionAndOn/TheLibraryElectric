using System;
using TMPro;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    // this is named after not enough photons since thrusters was originally an adamdev boneworks mod
    public class PhotonThruster : MonoBehaviour
    {
        public float thrustForce = 100f;
        public float ThrustForce
        {
            get => thrustForce;
            set => thrustForce = value;
        }
        public GameObject particles;
        public bool useText;
        public TextMeshPro textMeshPro;
        public float incrementAmount = 50f;
        public float decrementAmount = 50f;
        public float maximumForce = 500f;
        public float minimumForce = 50f;
        private bool _thrustEnabled;
        private Rigidbody _thisrb;
        
        private void Awake()
        {
            _thisrb = GetComponent<Rigidbody>();
            textMeshPro.text = thrustForce.ToString("F1");
        }

        public void Toggle()
        {
            if (_thrustEnabled)
            {
                _thrustEnabled = false;
                particles.SetActive(false);
            }
            else
            {
                _thrustEnabled = true;
                particles.SetActive(true);
            }
        }

        public void IncreaseForce()
        {
            if (thrustForce > maximumForce)
            {
                thrustForce += incrementAmount;
            }
            else
            {
                thrustForce = maximumForce;
            }
            if (useText)
            {
                UpdateTextValue(incrementAmount, false);
            }
        }

        public void DecreaseForce()
        {
            if (thrustForce < minimumForce)
            {
                thrustForce -= decrementAmount;
            }
            else
            {
                thrustForce = minimumForce;
            }
            if (useText)
            {
                UpdateTextValue(decrementAmount, true);
            }
        }
        
        public void UpdateTextValue(float value, bool subtract)
        {
            if (subtract)
            {
                var currentValue = float.Parse(textMeshPro.text);
                currentValue -= value;
                if (currentValue < minimumForce)
                {
                    currentValue = minimumForce;
                }
                textMeshPro.text = currentValue.ToString("F1");
            }
            else
            {
                var currentValue = float.Parse(textMeshPro.text);
                currentValue += value;
                if (currentValue > maximumForce)
                {
                    currentValue = maximumForce;
                }
                textMeshPro.text = currentValue.ToString("F1");
            }
        }
        
        private void FixedUpdate()
        {
            if (_thrustEnabled)
            {
                _thisrb.AddRelativeForce(transform.forward * thrustForce);
            }
        }
#if !UNITY_EDITOR
        public PhotonThruster(IntPtr ptr) : base(ptr) { }
#endif
    }
}