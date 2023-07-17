using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim.Result
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TrajectoryStruct
    {
        public int TrackID;
        public int ParentID;
        [MarshalAs(UnmanagedType.LPStr)] public string ParticleName;
        public double Charge;
        public int PDGEncoding;
        public double InitialKineticEnergy;
        public ThreeVector InitialMomentum;
        public int PointEntries;
        //[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)] public TrajectoryPoint[] Point;
    
//    public ParticleDefinition ToDo: いずれこれも追加すべき
//    public AttDefs ToDo: いずれこれも追加すべき
//    public TrajectoryPoint Point(int i)
//    {
//        return Marshal.PtrToStructure<TrajectoryPoint>(_point + Marshal.SizeOf<TrajectoryPoint>() * i);
//    }
    }

    public class Trajectory
    {
        public TrajectoryStruct TrajectoryStruct;
        public List<TrajectoryPoint> Points;

        public int TrackID => TrajectoryStruct.TrackID;
        public int ParentID => TrajectoryStruct.ParentID;
        public string ParticleName => TrajectoryStruct.ParticleName;
        public float Charge => (float) TrajectoryStruct.Charge;
        public int PDGEncoding => TrajectoryStruct.PDGEncoding;
        public float InitialKineticEnergy => (float) TrajectoryStruct.InitialKineticEnergy;
        public Vector3 InitialMomentum => TrajectoryStruct.InitialMomentum.AsUnityMomentum;
        public int PointEntries => TrajectoryStruct.PointEntries;
    }
}