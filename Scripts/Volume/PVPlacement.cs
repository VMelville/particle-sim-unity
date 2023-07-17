using System;
using System.Runtime.InteropServices;

namespace ParticleSim.Volume
{
    public class PVPlacement : IPointerGettable, IVolume
    {
        private RotationMatrix _rotation;
        private ThreeVector _position;
        private IntPtr _logicalVolume;
        private string _name;
        private int _copyNo;

        private IntPtr Ptr;
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreatePVPlacement(RotationMatrix rotation, ThreeVector position, string name, IntPtr logicalVolume, IntPtr mother, bool many, int copyNo, bool surfChk);
        
        public PVPlacement(RotationMatrix rotation, ThreeVector position, string name, IntPtr logicalVolume, IntPtr mother, int copyNo)
        {
            _rotation = rotation;
            _position = position;
            _logicalVolume = logicalVolume;
            _name = name;
            _copyNo = copyNo;
            
            Ptr = CreatePVPlacement(rotation, position, name, logicalVolume, mother, false, copyNo, true);
        }

        public override string ToString()
        {
            return "Rotation:" + _rotation + "\n" +
                   "Position:" + _position + "\n" +
                   "LogicalVolume" + _logicalVolume + "\n" +
                   "Name" + _name + "\n" +
                   "CopyNo" + _copyNo;
        }

        public IntPtr GetPointer() => Ptr;
    }
}
