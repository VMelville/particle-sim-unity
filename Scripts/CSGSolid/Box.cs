using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim.CSGSolid
{
    public class Box : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateBox(string name, double x, double y, double z);

        private Vector3 _unityCubeScale;
        
        // ToDo: コンストラクタでVector3を使うのはちょっと微妙な気がする
        private Box(string name, Vector3 unityCubeScale)
        {
            _unityCubeScale = unityCubeScale;
            var g4Scale = ThreeVector.ScaleToG4Vec(unityCubeScale);
            Ptr = CreateBox(name, g4Scale.x, g4Scale.y, g4Scale.z);
        }
        
        public Vector3 GetUnityCubeScale() => _unityCubeScale;
        
        public static Box CreateBoxFromUnityCubeScale(string name, Vector3 unityCubeScale)
        {
            return new Box(name, unityCubeScale);
        }
    }
}

