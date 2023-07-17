using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Torus : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateTorus(string name, double rMin, double rMax, double rTor, double sPhi, double dPhi);
        
        public Torus(string name, double rMin, double rMax, double rTor, double sPhi, double dPhi)
        {
            Ptr = CreateTorus(name, rMin, rMax, rTor, sPhi, dPhi);
        }
    }
}
