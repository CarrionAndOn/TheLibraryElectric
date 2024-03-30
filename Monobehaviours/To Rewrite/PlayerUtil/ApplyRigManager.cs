using System;
using BoneLib;
using SLZ.Bonelab;
using SLZ.Rig;
using UnityEngine;
using TheLibraryElectric.Melon;

namespace TheLibraryElectric.PlayerUtil
{ 
    public class ApplyRigManager : MonoBehaviour
    {
        public bool playerLeash;
        public Simple_PlayerLeasher playerLeasher;
        public bool playerLaunchPad;
        public PlayerLaunchPad[] playerLaunchPads;
        public bool forceAvatar;
        public ForceAvatar[] forceAvatars;
        public bool randomAvatar;
        public RandomAvatar[] randomAvatars;

        public RigManager _rigManager;
        public void Apply()
        {
            _rigManager = Player.rigManager;
            ModConsole.Msg($"Playerleash is {playerLeash}", 1);
            ModConsole.Msg($"PlayerLaunchPad is {playerLaunchPad}", 1);
            ModConsole.Msg($"ForceAvatar is {forceAvatar}", 1);
            ModConsole.Msg($"RandomAvatar is {randomAvatar}", 1);
            if (playerLeash)
            {
                ModConsole.Msg($"Executing PlayerLeash", 1);
                PlayerLeash();
            }
            if (playerLaunchPad)
            {
                ModConsole.Msg($"Executing PlayerLaunchPad", 1);
                PlayerLaunchPad();
            }
            if (forceAvatar)
            {
                ModConsole.Msg($"Executing ForceAvatar", 1);
                ForceAvatar();
            }
            if (randomAvatar)
            {
                ModConsole.Msg($"Executing RandomAvatar", 1);
                RandomAvatar();
            }
        }

        public void PlayerLeash()
        {
            playerLeasher.rM = _rigManager;
            ModConsole.Msg($"PlayerLeasher RM is {playerLeasher.rM}", 1);
            playerLeasher.gameObject.SetActive(true);
        }
        
        public void PlayerLaunchPad()
        {
            foreach (var launchPad in playerLaunchPads)
            {
                launchPad.rigManager = _rigManager;
                ModConsole.Msg($"PlayerLaunchPad RM is {launchPad.rigManager}", 1);
                launchPad.gameObject.SetActive(true);
            }
        }
        
        public void ForceAvatar()
        {
            foreach (var avatar in forceAvatars)
            {
                ModConsole.Msg($"ForceAvatar RM is {avatar.rm}", 1);
                avatar.rm = _rigManager;
                avatar.gameObject.SetActive(true);
            }
        }
        
        public void RandomAvatar()
        {
            foreach (var avatar in randomAvatars)
            {
                ModConsole.Msg($"RandomAvatar RM is {avatar.rm}", 1);
                avatar.rm = _rigManager;
                avatar.gameObject.SetActive(true);
            }
        }
        
#if !UNITY_EDITOR
        public ApplyRigManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}