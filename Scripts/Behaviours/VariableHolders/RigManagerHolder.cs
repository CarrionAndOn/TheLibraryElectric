using System;
#if MELONLOADER
using BoneLib;
#endif
using SLZ.Rig;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("Weather Electric/The Library Electric/Variable Holders/RigManager Holder")]
#endif
    public class RigManagerHolder : MonoBehaviour
    {
        public RigManager Variable { get; set; }
        public bool grabRigManagerOnStart = true;

#if MELONLOADER
        public void Awake()
        {
            if (grabRigManagerOnStart)
            {
                GrabRigManager();
            }
        }
        
        public void GrabRigManager()
        {
            Variable = Player.rigManager;
        }
#else
        public void Awake()
        {
            if (grabRigManagerOnStart)
            {
                GrabRigManager();
            }
        }

        public void GrabRigManager()
        {
            Variable = FindObjectOfType<RigManager>();
        }
#endif
        
#if MELONLOADER
        public RigManagerHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
