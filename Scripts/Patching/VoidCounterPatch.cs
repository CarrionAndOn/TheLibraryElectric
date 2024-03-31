using HarmonyLib;
using UnityEngine;
using SLZ.Marrow.Pool;
using SLZ;
using WeatherElectric.TheLibraryElectric.Behaviours.Markers;

namespace WeatherElectric.TheLibraryElectric.Patching
{
    public static class VoidCounterPatch
    {
        [HarmonyPatch(typeof(RigidbodyProjectile), "OnCollisionEnter")]
        public class VoidCounterPatch_Patch
        {
            // Prefix method runs before the original method (OnFire) is executed
            [HarmonyPrefix]
            public static bool Prefix(AssetPoolee __instance, Collision c)
            {
                if (c.gameObject.GetComponentInParent<VoidCounterObject>() != null) // Check if the colliding GameObject has the VoidCounterObject component
                {
                    var dynamicMaterial = new PhysicMaterial
                    {
                        bounciness = 1f,  
                        dynamicFriction = 0.2f,
                        staticFriction = 0.5f
                    };
                    Collider[] colliders = __instance.GetComponentsInChildren<Collider>();
                    foreach (var collider in colliders)
                    {
                        collider.material = dynamicMaterial;
                    }
                    if (__instance.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        __instance.gameObject.GetComponent<Rigidbody>().mass = 0.1f; // Set mass to 0.1f so it's easier to hit
                    }
                    if (c.gameObject.GetComponentInParent<VoidCounterObject>().disableDespsawnDelay)
                    {
                        if (__instance.gameObject.GetComponent<DisableDelay>() != null) {
                            DisableDelay[] disableDelays = __instance.gameObject.GetComponentsInChildren<DisableDelay>();
                            foreach (var disableDelay in disableDelays)
                            {
                                UnityEngine.Object.Destroy(disableDelay);
                            }
                        }
                    }
                    return false; // Prevent the ball from exploding by not running the original method
                }
                return true; // Run the original method, so it explodes
            }
        }
    }
}