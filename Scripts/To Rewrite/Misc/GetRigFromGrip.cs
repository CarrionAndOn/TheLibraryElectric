using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLZ.Interaction;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class GetRigFromGrip : MonoBehaviour
    { 
        public RigManager GetRig(Grip grip)
        {
            return grip.GetHand().GetComponentInParent<RigManager>();
        }
#if !UNITY_EDITOR
        public GetRigFromGrip(IntPtr ptr) : base(ptr) { }
#endif
    }
}
