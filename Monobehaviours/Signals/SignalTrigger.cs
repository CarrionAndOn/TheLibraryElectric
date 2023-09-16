using System;
using UnityEngine;
using UltEvents;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Signals
{
#if UNITY_EDITOR
[AddComponentMenu("The Library Electric/Signals/Signal Trigger")]
[RequireComponent(typeof(Collider))]
#endif
    public class SignalTrigger : MonoBehaviour
    {
        public UltEventHolder triggerEnterEvent;
        public UltEventHolder triggerExitEvent;
        public string activationKey;
        private void Start()
        {
            ModConsole.Msg($"SignalTrigger spawned, key is {activationKey}", LoggingMode.DEBUG);
        }
        private void OnTriggerEnter(Collider other)
        {
            var triggerer = other.GetComponent<SignalTriggerer>();
            if (triggerer != null)
            {
                if (triggerer.activationKey == activationKey)
                {
                    ModConsole.Msg($"Trigger's key is {activationKey}, triggerer's key is {triggerer.activationKey}", LoggingMode.DEBUG);
                    triggerEnterEvent.Invoke();
                    ModConsole.Msg("Invoked event", LoggingMode.DEBUG);
                }
                else
                {
                    ModConsole.Msg("Object is not a triggerer, or is not the right key.", LoggingMode.DEBUG);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var triggerer = other.GetComponent<SignalTriggerer>();
            if (triggerer != null)
            {
                if (triggerer.activationKey == activationKey)
                {
                    ModConsole.Msg($"Trigger's key is {activationKey}, triggerer's key is {triggerer.activationKey}", LoggingMode.DEBUG);
                    triggerExitEvent.Invoke();
                    ModConsole.Msg("Invoked event", LoggingMode.DEBUG);
                }
                else
                {
                    ModConsole.Msg("Object is not a triggerer, or is not the right key.", LoggingMode.DEBUG);
                }
            }
        }
        #if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			if (Selection.activeGameObject == gameObject)
				return;
            Collider collider = GetComponent<Collider>();

            if (collider != null && (collider is CapsuleCollider || collider is BoxCollider || collider is SphereCollider))
            {
                Gizmos.color = Color.yellow;

                // Draw gizmo based on collider type
                if (collider is CapsuleCollider)
                {
                    DrawCapsuleGizmo((CapsuleCollider)collider);
                }
                else if (collider is BoxCollider)
                {
                    DrawBoxGizmo((BoxCollider)collider);
                }
                else if (collider is SphereCollider)
                {
                    DrawSphereGizmo((SphereCollider)collider);
                }
            }
        }
        private void DrawCapsuleGizmo(CapsuleCollider capsuleCollider)
        {
            Vector3 position = transform.position + capsuleCollider.center;
			float height = capsuleCollider.height * transform.lossyScale.y;
			float radius = capsuleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.z);
			Vector3 boxSize = new Vector3(radius * 2, height - 2 * radius, radius * 2);
			Gizmos.DrawWireSphere(position + Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireSphere(position - Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireCube(position, boxSize);
        }

        private void DrawBoxGizmo(BoxCollider boxCollider)
        {
            Vector3 position = transform.position + boxCollider.center;
            Vector3 size = Vector3.Scale(boxCollider.size, transform.lossyScale);
            Gizmos.DrawWireCube(position, size);
        }

        private void DrawSphereGizmo(SphereCollider sphereCollider)
        {
            Vector3 position = transform.position + sphereCollider.center;
            float radius = sphereCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
            Gizmos.DrawWireSphere(position, radius);
        }
#endif
#if !UNITY_EDITOR
        public SignalTrigger(IntPtr ptr) : base(ptr) { }
#endif
    }
}