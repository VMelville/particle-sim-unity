using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Para : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreatePara(string name, double dx, double dy, double dz, double alpha, double theta, double phi);
        
        public Para(string name, double dx, double dy, double dz, double alpha, double theta, double phi)
        {
            Ptr = CreatePara(name, dx, dy, dz, alpha, theta, phi);
        }
    }
}
