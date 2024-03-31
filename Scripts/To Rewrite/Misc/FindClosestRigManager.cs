using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SLZ.Rig;
using JetBrains.Annotations;
using LabFusion.Extensions;

namespace TheLibraryElectric.Misc
{
    public class FindClosestRigManager : MonoBehaviour
    {
        public List<RigManager> rigsToIgnore = new List<RigManager>();
        private RigManager _closestRig;
        public void SetIgnoredRig(RigManager rm)
        {
            rigsToIgnore.Clear();
            rigsToIgnore.Add(rm);
        }
        public void AddIgnoredRig(RigManager rm)
        {
            rigsToIgnore.Add(rm);
        }
        public void RemoveIgnoredRig(RigManager rm)
        {
            rigsToIgnore.Remove(rm);
        }


        public Transform FindClosestRig()
        {
            RigManager[] rigs = FindObjectsOfType<RigManager>();
            foreach(RigManager rig in rigs)
            {
                if(_closestRig == null)
                {
                    _closestRig = rig;
                }
                else if(Vector3.Distance(transform.position, _closestRig.physicsRig.m_chest.transform.position) > Vector3.Distance(transform.position, rig.physicsRig.m_chest.transform.position))
                {
                    _closestRig = rig;
                }
            }
            return _closestRig.transform;

        }
#if !UNITY_EDITOR
        public FindClosestRigManager(IntPtr ptr) : base(ptr) { }
#endif
    }
}
