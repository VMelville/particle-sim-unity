using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RotationMatrix
    {
        private double xx;
        private double xy;
        private double xz;
        private double yx;
        private double yy;
        private double yz;
        private double zx;
        private double zy;
        private double zz;

        private RotationMatrix(Quaternion rotation)
        {
            rotation = new Quaternion(-rotation.x, -rotation.y, rotation.z, rotation.w);
            var matrix = new Matrix4x4();
            matrix.SetTRS(Vector3.zero, rotation, Vector3.one);
            matrix = matrix.transpose;
            xx = matrix.m00;
            xy = matrix.m01;
            xz = matrix.m02;
            yx = matrix.m10;
            yy = matrix.m11;
            yz = matrix.m12;
            zx = matrix.m20;
            zy = matrix.m21;
            zz = matrix.m22;
        }
    
        public override string ToString()
        {
            return xx + ", " + xy + ", " + xz + "\n" + yx + ", " + yy + ", " + yz + "\n" + zx + ", " + zy + ", " + zz;
        }

        public static RotationMatrix RotationToG4Mat(Quaternion quaternion)
        {
            return new RotationMatrix(quaternion);
        }
    }
}
