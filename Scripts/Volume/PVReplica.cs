using System;
using System.Runtime.InteropServices;

namespace ParticleSim.Volume
{
    public class PVReplica : IPointerGettable, IVolume
    {
        public enum EAxis
        {
            kXAxis,
            kYAxis,
            kZAxis,
            kRho,
            kRadial3D,
            kPhi,
            kUndefined,
        }
    
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreatePVReplica(string name, IntPtr logical, IntPtr mother, int axis, int nReplicas, double width, double offset);

        private IntPtr Ptr;
    
        public IntPtr GetPointer() => Ptr;

        public PVReplica(string name, LogicalVolume logical, IVolume mother, EAxis axis, int nReplicas, double width, double offset)
        {
            Ptr = CreatePVReplica(name, logical.GetPointer(), mother.GetPointer(), (int)axis, nReplicas, width, offset);
        }
    }
}
