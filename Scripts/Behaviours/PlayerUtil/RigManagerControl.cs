using System;
using UnityEngine;
using BoneLib;

namespace WeatherElectric.TheLibraryElectric.Behaviours.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Behaviours/Player Util/Player Control")]
#endif
    public class RigManagerControl : MonoBehaviour
    {
#if MELONLOADER
        public void RagDoll()
        {
            Player.physicsRig.RagdollRig();
        }
        public void UnRagDoll()
        {
            Player.physicsRig.UnRagdollRig();
        }
        public void Teleport(Vector3 feetPos)
        {
            Player.rigManager.Teleport(feetPos);
        }
        public void Teleport(Vector3 feetPos, bool zerovelocity)
        {
            Player.rigManager.Teleport(feetPos, zerovelocity);
        }
        public void Invincible()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.Invincible;
        }
        public void Mortal()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.Mortal;
        }
        public void InstantDeath()
        {
            Player.rigManager.health.healthMode = Health.HealthMode.InsantDeath;
        }
        public void EnableDoubleJump()
        {
            Player.remapRig.doubleJump = true;
        }
        public void DisableDoubleJump()
        {
            Player.remapRig.doubleJump = false;
        }
#else
        public void RagDoll()
        {

        }
        public void UnRagDoll()
        {

        }
        public void Teleport(Vector3 feetPos)
        {

        }
        public void Teleport(Vector3 feetPos, bool zerovelocity)
        {

        }
        public void Invincible()
        {

        }
        public void Mortal()
        {

        }
        public void InstantDeath()
        {

        }
        public void EnableDoubleJump()
        {

        }
        public void DisableDoubleJump()
        {

        }
#endif
        
#if MELONLOADER
        public RigManagerControl(IntPtr ptr) : base(ptr) { }
#endif
    }
}