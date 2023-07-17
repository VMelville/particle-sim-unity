using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Trap : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateTrap(string name, double dz, double theta, double phi, double dy1, double dx1, double dx2, double alp1, double dy2, double dx3, double dx4, double alp2);
        
        public Trap(string name, double dz, double theta, double phi, double dy1, double dx1, double dx2, double alp1, double dy2, double dx3, double dx4, double alp2)
        {
            Ptr = CreateTrap(name, dz, theta, phi, dy1, dx1, dx2, alp1, dy2, dx3, dx4, alp2);
        }
    }
}
