using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Trd : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateTrd(string name, double dx1, double dx2, double dy1, double dy2, double dz);

        public Trd(string name, double dx1, double dx2, double dy1, double dy2, double dz)
        {
            Ptr = CreateTrd(name, dx1, dx2, dy1, dy2, dz);
        }
    }
}
