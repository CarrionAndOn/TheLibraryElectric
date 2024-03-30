using System;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class TLE_SimpleRaycast : MonoBehaviour
    {
        public Vector3 SimpleSendRay(float maxDistance, Transform firePoint)
        {
            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxDistance))
            {
                return hit.transform.position;
            }
            return firePoint.position + firePoint.forward * maxDistance;
        }
        public GameObject SendRay(float maxDistance, Transform firePoint)
        {
            RaycastHit hit;
            Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxDistance);
            return hit.collider.gameObject;
        }
#if !UNITY_EDITOR
        public TLE_SimpleRaycast(IntPtr ptr) : base(ptr) { }
#endif
    }
}
