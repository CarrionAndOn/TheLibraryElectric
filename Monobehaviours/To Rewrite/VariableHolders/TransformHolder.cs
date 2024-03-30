using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.VariableHolders
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Variable Holders/Transform Holder")]
#endif
    public class TransformHolder : MonoBehaviour
    {
        public Transform variable;
        public Transform Variable
        {
            get { return variable; }
            set { variable = value; }
        }
#if !UNITY_EDITOR
        public TransformHolder(IntPtr ptr) : base(ptr) { }
#endif
    }
}
