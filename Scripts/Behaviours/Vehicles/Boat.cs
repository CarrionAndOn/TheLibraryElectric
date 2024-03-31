using UnityEngine;
using SLZ.SFX;
using SLZ.Vehicle;
using SLZ.Rig;
using static System.Math;
#if MELONLOADER
using UnhollowerRuntimeLib;
#endif
using System;
using WeatherElectric.TheLibraryElectric.Behaviours.Water;
using WeatherElectric.TheLibraryElectric.Melon;

namespace WeatherElectric.TheLibraryElectric.Behaviours.Vehicles
{
    
    public class Boat : MonoBehaviour
    {
        public MotorSFX motorSFX;
        public ParticleSystem[] Particles;
        public int ParticleCount = 5;
        public float DelayBetweenParticles = 0.1f;
        public float RandomVariance = 0.05f;
        public float WaterCheckDelay = 1f;
        public Rigidbody[] Bodiestocheck;

        public Seat DriverSeat;
        public Transform SteeringWheel;
        public Vector2 WheelMinMaxAngle;
        public bool CanReverse;

        public Transform[] Rudders;
        public Vector2 RudderMinMaxAngle;
        public Rigidbody BodyToAccelerate;
        public Rigidbody[] Propellers;
        public float PropellerForce;
        public Transform Speedometer;
        public float MaxSpeedometerRotation;

        public float Speed = 100;
        public float MaxSpeed = 15;
        public float MaxTurn = 100;
        public float MotorAccel = 15;
        public float DecelMultiplier = 2;
        public float ReverseMultiplier = 0.5f;

        private BaseController _Controller;
        private bool _IsPlayerIn = false;
        private float _JoystickY;
        private float _SteeringY;
        private float _SteeringRudderRatio = 1;
        private float _MotorStrength;
        private float _TimeCounter;
        private bool _IsInWater;
        private float _TimerChecks;
        private float _CurrentDelay = 0;
        private float _LastSpeed;

        void Start()
        {
            #if MELONLOADER
            DriverSeat.RegisteredEvent += DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(new Action(SeatEnter));
            DriverSeat.DeRegisteredEvent += DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(new Action(SeatExit));
            #else
            DriverSeat.RegisteredEvent += DelegateSupport.ConvertDelegate<Action>(new Action(SeatEnter));
            DriverSeat.DeRegisteredEvent += DelegateSupport.ConvertDelegate<Action>(new Action(SeatExit));
            #endif
            _CurrentDelay = DelayBetweenParticles + UnityEngine.Random.Range(-RandomVariance, RandomVariance);
            ModConsole.Msg("Getting absolute of should-be-positive-values", 1);
            ReverseMultiplier = Abs(ReverseMultiplier);
            DecelMultiplier = Abs(DecelMultiplier);
            MotorAccel = Abs(MotorAccel);
            MaxSpeed = Abs(MaxSpeed);
            WaterCheckDelay = Abs(WaterCheckDelay);
            ParticleCount = Abs(ParticleCount);
            if(DriverSeat == null)
            {
                ModConsole.Error("Driver seat is null. Can't fix!");
            }
            if(motorSFX == null)
            {
                ModConsole.Error("Motor SFX is null! Fixing...", 1);
                motorSFX = gameObject.AddComponent<MotorSFX>();
            }
            if(Speedometer == null)
            {
                ModConsole.Error("Speedometer is null! Disabling...", 1);
                MaxSpeedometerRotation = 0;
            }
            if(SteeringWheel == null)
            {
                ModConsole.Error("Steering wheel is null! Expect errors, fixing anyway...");
                SteeringWheel = new GameObject().transform;
                SteeringWheel.parent = transform;
            }
            if(BodyToAccelerate == null)
            {
                ModConsole.Msg("Body to accelerate is null! Trying to grab from this object...");
                Rigidbody foundBody = gameObject.GetComponent<Rigidbody>();
                if (foundBody == null)
                {
                    ModConsole.Msg("Couldn't find Rigidbody, adding one with some basic values...");
                    BodyToAccelerate = gameObject.AddComponent<Rigidbody>();
                    BodyToAccelerate.mass = Speed;
                }
                else
                {
                    ModConsole.Msg("Found a Rigidbody", 1);
                    BodyToAccelerate = foundBody;
                }
            }
        }

        void Update()
        {
            if (_IsPlayerIn)
            {
                _JoystickY = _Controller.GetThumbStickAxis().y;
            }
            else
            {
                _JoystickY = 0f;
            }
            if (_JoystickY * 100 < _MotorStrength)
            {
                _MotorStrength -= MotorAccel * DecelMultiplier * Time.deltaTime;
            }
            if (_JoystickY * 100 > _MotorStrength)
            {
                _MotorStrength += MotorAccel * Time.deltaTime;
            }
            if (CanReverse)
            {
                Mathf.Clamp(_MotorStrength, -100, 100);
            }
            Mathf.Clamp(_MotorStrength, 0, 100);
            _SteeringY = SteeringWheel.rotation.y;
            _SteeringRudderRatio = (RudderMinMaxAngle.y - RudderMinMaxAngle.x) / (WheelMinMaxAngle.y - WheelMinMaxAngle.x);
            if (Rudders.Length > 0)
            {
                foreach (Transform rudder in Rudders)
                {
                    rudder.Rotate(0f, -rudder.rotation.eulerAngles.y, 0f);
                    rudder.Rotate(0f, _SteeringY * _SteeringRudderRatio, 0f);
                }
            }
            if (MaxSpeedometerRotation != 0)
            {
                Speedometer.Rotate(0, -Speedometer.rotation.eulerAngles.y, 0);
                Speedometer.Rotate(0, MaxSpeedometerRotation / 100 * (MaxSpeed / Vector3.Dot(BodyToAccelerate.transform.forward, BodyToAccelerate.velocity) * 100), 0);
            }
            if (_TimeCounter > _CurrentDelay)
            {
                _TimeCounter = 0;
                _CurrentDelay = DelayBetweenParticles + UnityEngine.Random.Range(-RandomVariance, RandomVariance);
                if (_IsInWater && (Particles.Length > 0))
                {
                    foreach (ParticleSystem system in Particles)
                    {
                        system.Emit(ParticleCount);
                    }
                }
            }
            else
            {
                _TimeCounter += Time.deltaTime;
            }

        }
        
        private void FixedUpdate()
        {
            if (Sign(_MotorStrength) == -1)
            {
                BodyToAccelerate.AddRelativeForce(new Vector3(0f, 0f, _MotorStrength * Speed * DecelMultiplier));
            }
            BodyToAccelerate.AddRelativeForce(new Vector3(0f, 0f, _MotorStrength * Speed));
            BodyToAccelerate.velocity = new Vector3(Mathf.Clamp(BodyToAccelerate.velocity.x, float.MinValue, MaxSpeed), BodyToAccelerate.velocity.y, Mathf.Clamp(BodyToAccelerate.velocity.z, float.MinValue, MaxSpeed));
            if (!(-10 < _SteeringY && _SteeringY < 10))
            {
                BodyToAccelerate.AddRelativeTorque(new Vector3(0f, (MaxTurn / 100) * _SteeringY / (WheelMinMaxAngle.y - WheelMinMaxAngle.x) / 100, 0f));
            }
            if (Propellers.Length > 0)
            {
                foreach (Rigidbody propeller in Propellers)
                {
                    propeller.AddRelativeForce(new Vector3(0, PropellerForce * _MotorStrength, 0));
                }
            }
            if (_TimerChecks > WaterCheckDelay)
            {
                _TimerChecks = 0;
                if (Bodiestocheck.Length > 0)
                {
                    int wetbodies = 0;
                    foreach (Rigidbody body in Bodiestocheck)
                    {
                        RbBuoyancyManager wetness = body.gameObject.GetComponent<RbBuoyancyManager>();
                        if (wetness)
                        {
                            wetbodies += 1;
                        }
                    }
                    if (wetbodies > 0)
                    {
                        _IsInWater = true;
                    }
                    else
                    {
                        _IsInWater = false;
                    }
                }
                else if(BodyToAccelerate.gameObject.GetComponent<RbBuoyancyManager>() != null)
                {
                    _IsInWater = true;
                }
                else
                {
                    _IsInWater = false;
                }
            }
            else
            {
                _TimerChecks += Time.fixedDeltaTime;
            }

            float velocity = Vector3.Dot(BodyToAccelerate.transform.forward, BodyToAccelerate.velocity);
            motorSFX.UpdateMotor(velocity, (velocity - _LastSpeed)/Time.fixedDeltaTime , Abs(_MotorStrength));
            _LastSpeed = velocity;
        }

        private void OnDisable()
        {
            _IsPlayerIn = false;
        }

        private void SeatEnter()
        {
            motorSFX.StartMotor();
            _IsPlayerIn = true;
            if (DriverSeat.rigManager.ControllerRig.isRightHanded)
            {
                _Controller = DriverSeat.rigManager.ControllerRig.rightController;
            }
            else
            {
                _Controller = DriverSeat.rigManager.ControllerRig.leftController;
            }

        }

        private void SeatExit()
        {
            motorSFX.StopMotor();
            _Controller = null;
            _IsPlayerIn = false;
            _JoystickY = 0f;
        }
        
#if MELONLOADER
        public Boat(IntPtr ptr) : base(ptr) { }
#endif
    }
}