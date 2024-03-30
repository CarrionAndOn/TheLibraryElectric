using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Variable Holders/Vector3 Holder")]
#endif
    public class Vector3Holder : MonoBehaviour
    {
        public Vector3 variable;
        public Vector3 Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public Vector3Holder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
