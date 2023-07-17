using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ParticleSim.Result
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TrajectoryPointStruct
    {
        public ThreeVector Position;
        public double TotalEnergyDeposit;
        public double RemainingEnergy;
        [MarshalAs(UnmanagedType.LPStr)] public string ProcessDefinedStep;
        [MarshalAs(UnmanagedType.LPStr)] public string ProcessTypeDefinedStep;
        [MarshalAs(UnmanagedType.LPStr)] public string PreStepPointStatus;
        [MarshalAs(UnmanagedType.LPStr)] public string PostStepPointStatus;
        public double PreStepPointGlobalTime;
        public double PostStepPointGlobalTime;
        [MarshalAs(UnmanagedType.LPStr)] public string PreStepPointGlobalTimeStr;
        [MarshalAs(UnmanagedType.LPStr)] public string PostStepPointGlobalTimeStr;
        [MarshalAs(UnmanagedType.LPStr)] public string PreStepVolumePath;
        [MarshalAs(UnmanagedType.LPStr)] public string PostStepVolumePath;
        public double PreStepPointWeight;
        public double PostStepPointWeight;
        public int AuxiliaryPointsSize;
    }

    public class TrajectoryPoint
    {
        public TrajectoryPointStruct TrajectoryStruct;
        public List<ThreeVector> AuxiliaryPoints;
        public Vector3 UnityScalePrePosition;
        public Vector3 Velocity;
        public float Charge;
        
        public Vector3 UnityScalePostPosition => TrajectoryStruct.Position.AsUnityPos;
        public float TotalEnergyDeposit => (float) TrajectoryStruct.TotalEnergyDeposit;
        public float RemainingEnergy => (float) TrajectoryStruct.RemainingEnergy;
        public string ProcessDefinedStep => TrajectoryStruct.ProcessDefinedStep;
        public string ProcessTypeDefinedStep => TrajectoryStruct.ProcessTypeDefinedStep;
        public string PreStepPointStatus => TrajectoryStruct.PreStepPointStatus;
        public string PostStepPointStatus => TrajectoryStruct.PostStepPointStatus;
        public float PreStepPointGlobalTime => (float) TrajectoryStruct.PreStepPointGlobalTime;
        public float PostStepPointGlobalTime => (float) TrajectoryStruct.PostStepPointGlobalTime;
        public string PreStepPointGlobalTimeStr => TrajectoryStruct.PreStepPointGlobalTimeStr;
        public string PostStepPointGlobalTimeStr => TrajectoryStruct.PostStepPointGlobalTimeStr;
        public string PreStepVolumePath => TrajectoryStruct.PreStepVolumePath;
        public string PostStepVolumePath => TrajectoryStruct.PostStepVolumePath;
        public float PreStepPointWeight => (float) TrajectoryStruct.PreStepPointWeight;
        public float PostStepPointWeight => (float) TrajectoryStruct.PostStepPointWeight;
        public int AuxiliaryPointsSize => TrajectoryStruct.AuxiliaryPointsSize;
    }
}