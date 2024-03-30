using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLibraryElectric.Misc;
using UltEvents;
using UnityEngine;


namespace TheLibraryElectric.Misc
{
    // Thank you for making me do this SLZ
    public class PlungerButBetter : MonoBehaviour
    {
        
        public Rigidbody baseRB;
        public enum DetectionType
        {
            Trigger,
            Collision
        }
        public DetectionType detectionType;

        public float minimumForce;
        public float breakForce;
        public UltEvent onAttach;
        public UltEvent onDetach;
        public Rigidbody connectedRigidbody { get; set; }
        public FixedJoint joint { get; set; }

        private bool _isAttached = false;

        public void OnTriggerEnter(Collision collision)
        {
            if(detectionType == DetectionType.Trigger)
            {
                connectedRigidbody = collision.rigidbody;
                float velocity = collision.relativeVelocity.sqrMagnitude;
                if (velocity >= minimumForce)
                {
                    joint = baseRB.gameObject.AddComponent<FixedJoint>();
                    joint.breakForce = breakForce;
                    if(connectedRigidbody != null)
                    {
                        joint.connectedBody = connectedRigidbody;
                    }
                    var listener = baseRB.GetComponent<PlungerListener>();
                    if (listener == null)
                    {
                        baseRB.gameObject.AddComponent<PlungerListener>();
                    }
                    else
                    {
                        listener.plunger = this;
                        listener.joint = joint;
                    }
                    onAttach.Invoke();
                }
            }
        }
        public void OnCollisionEnter(Collider collider)
        {
            if (detectionType == DetectionType.Collision)
            {
                connectedRigidbody = collider.attachedRigidbody;
                float otherVelocity = connectedRigidbody.velocity.sqrMagnitude;
                float velocity = baseRB.velocity.sqrMagnitude;
                if (velocity >= minimumForce)
                {
                    joint = baseRB.gameObject.AddComponent<FixedJoint>();
                    joint.breakForce = breakForce;
                    if (connectedRigidbody != null)
                    {
                        joint.connectedBody = connectedRigidbody;
                    }
                    var listener = baseRB.GetComponent<PlungerListener>();
                    if(listener == null)
                    {
                        baseRB.gameObject.AddComponent<PlungerListener>();
                    }
                    else
                    {
                        listener.plunger = this;
                        listener.joint = joint;
                    }
                    onAttach.Invoke();
                }
                else if(connectedRigidbody != null && otherVelocity >= minimumForce)
                {
                    joint = baseRB.gameObject.AddComponent<FixedJoint>();
                    joint.breakForce = breakForce;
                    joint.connectedBody = connectedRigidbody;
                    var listener = baseRB.GetComponent<PlungerListener>();
                    if (listener == null)
                    {
                        baseRB.gameObject.AddComponent<PlungerListener>();
                    }
                    else
                    {
                        listener.plunger = this;
                        listener.joint = joint;
                    }
                    onAttach.Invoke();
                }
                
            }
        }
        public void Break()
        {
            _isAttached = false;
            connectedRigidbody = null;
            onDetach.Invoke();
        }
#if !UNITY_EDITOR
        public PlungerButBetter(IntPtr ptr) : base(ptr) { }
#endif
    }
}
