using System;
using UnityEngine;

namespace WeatherElectric.TheLibraryElectric.Behaviours
{
    public class ElectricBehaviour : MonoBehaviour
    {
	    public virtual string Comment => null;
	    public virtual string Warning => null;
	    public virtual string Error => null;
	    
		public ElectricBehaviour(IntPtr intPtr) : base(intPtr) { }
    }
}