using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class PlungerListener : MonoBehaviour
    {
        public PlungerButBetter plunger { get; set; }
        public FixedJoint joint { get; set; }

        public void OnJointBreak(float breakForce)
        {
            if(joint == null)
            {
                plunger.Break();
            }
        }
#if !UNITY_EDITOR
        public PlungerListener(IntPtr ptr) : base(ptr) { }
#endif
    }
}
