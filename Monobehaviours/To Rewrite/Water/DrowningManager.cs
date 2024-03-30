using System;
using SLZ.Bonelab;
using UnityEngine;
using SLZ.Rig;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Water
{
    public class DrowningManager : MonoBehaviour
    {
        public float timeUntilDrowning = 20f;
        public float damageInterval = 1f;
        public float damagePercentage = 0.10f;
        private RigManager _rigManager;
        private bool _isDrowning = false;
        private float _timeInsideWater = 0.0f;
        private float _methodCallTimer = 0.0f;

        private void OnTriggerEnter(Collider other)
        {
            _rigManager = other.GetComponentInParent<RigManager>();
            if (_rigManager != null)
            {
                _isDrowning = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            _isDrowning = false;
            _timeInsideWater = 0.0f;
        }
        // The car told me to do this and the car is right
        private void FixedUpdate()
        {
            if (_isDrowning)
            {
                CheckTimeInWater();
            }
        }
        private void CheckTimeInWater()
        {
            _timeInsideWater += Time.deltaTime;
            if (_timeInsideWater >= timeUntilDrowning)
            {
                RepeatDrownMethod();
            }
        }
        private void RepeatDrownMethod()
        {
            _methodCallTimer += Time.deltaTime;

            if (_methodCallTimer >= damageInterval)
            {
                Drown();
                _methodCallTimer = 0.0f;
            }
        }
        private void Drown()
        {
            var damageTaken = _rigManager.health.max_Health * damagePercentage;
            _rigManager.health.TAKEDAMAGE(damageTaken);
        }
#if !UNITY_EDITOR
        public DrowningManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}