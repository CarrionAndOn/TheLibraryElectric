using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLZ.Rig;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Variable Holders/RigManager Holder")]
#endif
    public class RigManagerHolder : MonoBehaviour
    {
        public RigManager variable;
        public RigManager Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public RigManagerHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
