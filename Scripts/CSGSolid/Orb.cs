using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim.CSGSolid
{
    public class Orb : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateBox(string name, double rMax);

        private Vector3 _unitySphereScale;
        
        private Orb(string name, Vector3 unitySphereScale)
        {
            _unitySphereScale = unitySphereScale;
            var g4Scale = ThreeVector.ScaleToG4Vec(unitySphereScale);
            Ptr = CreateBox(name, (g4Scale.x + g4Scale.y + g4Scale.z) / 3.0); //　なんとなく平均とっとく
        }

        public Vector3 GetUnitySphereScale() => _unitySphereScale;

        public static Orb CreateBoxFromUnityCubeScale(string name, Vector3 unitySphereScale)
        {
            return new Orb(name, unitySphereScale);
        }
    }
}
