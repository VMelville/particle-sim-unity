using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim.CSGSolid
{
    public class Tubs : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateTubs(string name, double rMin, double rMax, double dz, double sPhi, double dPhi);

//        public Tubs(string name, double rMin, double rMax, double dz, double sPhi, double dPhi)
        public Tubs(string name, Vector3 unityCylinderScale)
        {
            var rMax = (unityCylinderScale.x + unityCylinderScale.z) * 250.0;
            var dz = unityCylinderScale.y * 1000.0;
            Ptr = CreateTubs(name, 0, rMax, dz, 0, Mathf.PI * 2.0);
        }

        public static CSGSolid CreateTubsFromUnityCylinderScale(string world, Vector3 unityCylinderScale)
        {
            return new Tubs(world, unityCylinderScale);
        }
    }
}
