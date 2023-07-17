using System;
using System.Runtime.InteropServices;
using ParticleSim.CSGSolid;
using UnityEngine;

namespace ParticleSim.Volume
{
    public class LogicalVolume : IPointerGettable, IVolume, IDisposable
    {
        private IntPtr _ptr;
        private string _name;
        private CSGSolid.CSGSolid _solid;

        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr FindOrBuildMaterial(string materialName);
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateFieldManagerWithMagField(ThreeVector magFieldVec);

        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateLogicalVolume(IntPtr pSolid, IntPtr pMaterial, string name);
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateLogicalVolumeWithField(IntPtr pSolid, IntPtr pMaterial, string name, IntPtr fieldManager);
        
        public LogicalVolume(CSGSolid.CSGSolid solid, string name, string materialName)
        {
            _name = name;
            _solid = solid;
            _ptr = CreateLogicalVolume(solid.GetPointer(), FindOrBuildMaterial(materialName), name);
        }
        
        public LogicalVolume(CSGSolid.CSGSolid solid, string name, string materialName, ThreeVector magFieldVec)
        {
            _name = name;
            _solid = solid;
            _ptr = CreateLogicalVolumeWithField(solid.GetPointer(), FindOrBuildMaterial(materialName), name, CreateFieldManagerWithMagField(magFieldVec));
        }

        public LogicalVolume()
        {
        }

        public IntPtr GetPointer() => _ptr;
        public CSGSolid.CSGSolid GetCSGSolid() => _solid;
        public string GetName() => _name;

        public Vector3 GetScaleForUnity()
        {
            return _solid switch
            {
                Box box => box.GetUnityCubeScale(),
                Orb orb => orb.GetUnitySphereScale(),
                _ => Vector3.one
            };
        }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(_ptr);
        }
    }
}
