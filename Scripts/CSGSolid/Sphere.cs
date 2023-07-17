using System;
using System.Runtime.InteropServices;

namespace ParticleSim.CSGSolid
{
    public class Sphere : CSGSolid
    {
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr CreateSphere(string name, double rMin, double rMax, double sPhi, double dPhi, double sTheta, double dTheta);

        private Sphere(string name, double rMin, double rMax, double sPhi, double dPhi, double sTheta, double dTheta)
        {
            Ptr = CreateSphere(name, rMin, rMax, sPhi, dPhi, sTheta, dTheta);
        }
    }
}
