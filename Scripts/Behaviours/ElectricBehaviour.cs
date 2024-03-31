using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours
{
#if UNITY_EDITOR
	[HideInInspector]
#endif
    public class ElectricBehaviour : MonoBehaviour
    {
	    public virtual string Comment => null;
	    public virtual string Warning => null;
	    public virtual string Error => null;
	    
	    #if MELONLOADER
		public ElectricBehaviour(IntPtr intPtr) : base(intPtr) { }
		#endif
    }
}