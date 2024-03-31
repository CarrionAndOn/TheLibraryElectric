using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class SpawnOnTriggerEnter : MonoBehaviour
    {

        public GameObject objectToSpawn;
        public bool divideVelocity;
        public float divideByX = 10f;
        public float divideByY = 10f;
        public float divideByZ = 10f;
        public Vector3 minimumScale = new Vector3(1, 1, 1);
        public Vector3 maximumScale = new Vector3(200, 200, 200);
        public bool uniformScale = true;
        public float uniformScaleMinimum = 1f;
        public float uniformScaleMaximum = 200f;
        public float uniformScaleDivision = 10f;
        public bool ignoreSpawnedObjects = false;
        public bool fixedRotation = true;
        public Quaternion rotation = new Quaternion(0, 0, 1, 0);
        public float minimumVelocity = 0.5f;
        public bool fixedY = true;
        public float YValue = 0f;

        private Vector3 rbVelocity;
        private List<GameObject> spawnedObjects = new List<GameObject>();
        private GameObject spawnedObject;
        private void OnTriggerEnter(Collider other)
        {
            if (objectToSpawn == null)
            {
                return;
            }
            if (spawnedObjects.Contains(other.transform.root.gameObject) && ignoreSpawnedObjects)
            {
                return;
            }
            if (other.attachedRigidbody.velocity.sqrMagnitude < minimumVelocity)
            {
                return;
            }
            if (fixedRotation)
            {
                if (fixedY)
                {
                    Vector3 fixedYPosition = new Vector3(other.transform.position.x, YValue, other.transform.position.z);
                    spawnedObject = Instantiate(objectToSpawn, fixedYPosition, rotation);
                }
                else
                {
                    spawnedObject = Instantiate(objectToSpawn, other.transform.position, rotation);
                }
            }
            else
            {
                if (fixedY)
                {
                    Vector3 fixedYPosition = new Vector3(other.transform.position.x, YValue, other.transform.position.z);
                    spawnedObject = Instantiate(objectToSpawn, fixedYPosition, other.transform.rotation);
                }
                else
                {
                    spawnedObject = Instantiate(objectToSpawn, other.transform.position, other.transform.rotation);
                }

            }
            if (!uniformScale)
            {
                var clampedX = Mathf.Clamp(Mathf.Abs(other.attachedRigidbody.velocity.x) / divideByX, minimumScale.x, maximumScale.x);
                var clampedY = Mathf.Clamp(Mathf.Abs(other.attachedRigidbody.velocity.y) / divideByY, minimumScale.y, maximumScale.y);
                var clampedZ = Mathf.Clamp(Mathf.Abs(other.attachedRigidbody.velocity.z) / divideByZ, minimumScale.z, maximumScale.z);
                rbVelocity = new Vector3(clampedX, clampedY, clampedZ);
                spawnedObject.transform.localScale = Vector3.Scale(rbVelocity, spawnedObject.transform.lossyScale);
            }
            else
            {
                rbVelocity = new Vector3(Mathf.Abs(other.attachedRigidbody.velocity.x), Mathf.Abs(other.attachedRigidbody.velocity.y), Mathf.Abs(other.attachedRigidbody.velocity.z));
                var uniformScale = Mathf.Clamp(rbVelocity.sqrMagnitude / uniformScaleDivision, uniformScaleMinimum, uniformScaleMaximum);
                var newScale = new Vector3(uniformScale, uniformScale, uniformScale);
                spawnedObject.transform.localScale = newScale;
            }

        }
#if !UNITY_EDITOR
        public SpawnOnTriggerEnter(IntPtr ptr) : base(ptr) { }
#endif
    }
}