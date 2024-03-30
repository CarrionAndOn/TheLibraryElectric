using System;
using LabFusion.SDK.Points;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.LabFusion
{
    public class BitShop : MonoBehaviour
    {
        public int bitsRequired;
        public UltEvent purchaseEvent;
        public UltEvent noBitsEvent;
        public void Purchase()
        {
            var bits = PointItemManager.GetBitCount();
            if (bits >= bitsRequired)
            {
                purchaseEvent.Invoke();
                PointItemManager.DecrementBits(bitsRequired, true);
            }
            else
            {
                noBitsEvent.Invoke();
            }
        }
#if !UNITY_EDITOR
        public BitShop(IntPtr ptr) : base(ptr) { }
#endif
    }
}