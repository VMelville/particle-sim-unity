using System.Runtime.InteropServices;

namespace ParticleSim
{
    public class PDG
    {
        [DllImport("particle-sim-native-plugin.dll")]
        public static extern string GetParticleName(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGMass(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGWidth(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGCharge(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGSpin(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiSpin(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiParity(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiConjugation(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGIsospin(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGIsospin3(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiIsospin(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiIsospin3(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGiGParity(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGMagneticMoment(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern string GetParticleType(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern string GetParticleSubType(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetLeptonNumber(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetBaryonNumber(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetPDGEncoding(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetAntiPDGEncoding(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetQuarkContent(string particleName, int flavor);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetAntiQuarkContent(string particleName, int flavor);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern bool GetPDGStable(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern double GetPDGLifeTime(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetAtomicNumber(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetAtomicMass(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern int GetVerboseLevel(string particleName);

        [DllImport("particle-sim-native-plugin.dll")]
        public static extern bool GetApplyCutsFlag(string particleName);
    }
}
