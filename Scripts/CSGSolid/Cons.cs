using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Cons : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateCons(string name, double rMin1, double rMax1, double rMin2, double rMax2, double dz, double sPhi, double dPhi);
        
        public Cons(string name, double rMin1, double rMax1, double rMin2, double rMax2, double dz, double sPhi, double dPhi)
        {
            Ptr = CreateCons(name, rMin1, rMax1, rMin2, rMax2, dz, sPhi, dPhi);
        }
    }
}
