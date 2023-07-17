using System.Runtime.InteropServices;
using UnityEngine;

// Unity.Vector3と違って、各要素がdoubleであることに注意
namespace ParticleSim
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ThreeVector
    {
        public double x;
        public double y;
        public double z;

        public Vector3 AsUnityPos => new Vector3((float) x, (float) y, (float) -z) * 0.001f;
        public Vector3 AsUnityMomentum => new Vector3((float) x, (float) y, (float) -z) * 1f; // ToDo: わかりやすいスケールをかける
        public Vector3 AsUnityScale => new Vector3((float) x, (float) y, (float) z) * 0.002f;

        private ThreeVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private ThreeVector(Vector3 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        public static ThreeVector PositionToG4Vec(Vector3 position)
        {
            var v = position * 1000f;
            return new ThreeVector(v.x, v.y, -v.z);
        }

        public static ThreeVector ScaleToG4Vec(Vector3 scale)
        {
            return new ThreeVector(scale * 500f);
        }

        public static ThreeVector DirectionToG4Vec(Vector3 direction)
        {
            return new ThreeVector(direction.x, direction.y, -direction.z);
        }

        public static ThreeVector MagFieldToG4Vec(Vector3 magField)
        {
            var v = magField * 0.001f;
            return new ThreeVector(v.x, v.y, -v.z); // Geant4では 1 = 1000kT なので、0.001をかけて　1 が 1 Tesla になるようにしています。
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
