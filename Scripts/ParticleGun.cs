using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ParticleGun
    {
        public int NumberOfParticle;
        public string ParticleName;
        public ThreeVector Position;
        public ThreeVector Direction;
        public double Energy;

        public ParticleGun(string particleName, double energy)
        {
            NumberOfParticle = 1;
            ParticleName = particleName;
            Position = ThreeVector.PositionToG4Vec(Vector3.zero);
            Direction = ThreeVector.DirectionToG4Vec(Random.insideUnitSphere);
            Energy = energy;
        }
    }
}

