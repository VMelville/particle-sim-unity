using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ParticleSim.Result;
using ParticleSim.Volume;
using UnityEngine;

namespace ParticleSim
{
    public class Simulator : MonoBehaviour
    {
        [DllImport("particle-sim-native-plugin.dll")]
        public static extern void Init();
    
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern void BeamOn();
    
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern void SetParticleGun(ParticleGun particleGun);
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern void SetWorldVolume(IntPtr worldVolume);
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern void InitializeGeometry();
        
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern void ReinitializeGeometry();
    
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern int GetTrajectoryContainerEntries();

        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr GetTrajectory(int trajectoryIndex);

        [DllImport("particle-sim-native-plugin.dll")]
        private static extern IntPtr GetTrajectoryPoint(int trajectoryIndex, int pointIndex);
    
        [DllImport("particle-sim-native-plugin.dll")]
        private static extern ThreeVector GetAuxiliaryPoint(int trajectoryIndex, int pointIndex, int auxiliaryPointIndex);
    
        private List<Trajectory> _trajectories;
        
        public static SimulationResult RunSimulation(ParticleGun particleGun, PVPlacement worldPvp)
        {
            // Run Simulator
            SetParticleGun(particleGun);
            
            SetWorldVolume(worldPvp.GetPointer());
            
            ReinitializeGeometry(); // メモ ここでクラッシュしてる

            BeamOn();

            // ------------------------------------------------------
            
            // Get And Process Data
            var result = new SimulationResult();
            
            for (var i = 0; i < GetTrajectoryContainerEntries(); i++)
            {
                var trajectory = new Trajectory
                {
                    TrajectoryStruct = Marshal.PtrToStructure<TrajectoryStruct>(GetTrajectory(i)),
                    Points = new List<TrajectoryPoint>()
                };
                
                for (var j = 0; j < trajectory.PointEntries; j++)
                {
                    var trajectoryPoint = new TrajectoryPoint
                    {
                        TrajectoryStruct = Marshal.PtrToStructure<TrajectoryPointStruct>(GetTrajectoryPoint(i, j)),
                        AuxiliaryPoints = new List<ThreeVector>(),
                        Charge = trajectory.Charge
                    };

                    var startTime = trajectoryPoint.PreStepPointGlobalTime; 
                    var endTime = trajectoryPoint.PostStepPointGlobalTime;

                    if (j > 0)
                    {
                        trajectoryPoint.UnityScalePrePosition = trajectory.Points[j - 1].UnityScalePostPosition;
                        trajectoryPoint.Velocity = (trajectoryPoint.UnityScalePostPosition - trajectoryPoint.UnityScalePrePosition) / (endTime - startTime);
                    }

                    if (startTime < endTime) // 等しい場合可視化に現れないとみなせるので省略
                    {
                        result.LinearTrajectory.Add(new LinerTrajectory
                        {
                            Charge = trajectory.Charge,
                            StartTime = startTime,
                            EndTime = endTime,
                            Slope = trajectoryPoint.Velocity,
                            Intercept = trajectoryPoint.UnityScalePrePosition - trajectoryPoint.Velocity * startTime
                        });
                    }

                    trajectory.Points.Add(trajectoryPoint);
                }
                
                result.Trajectories.Add(trajectory);
            }
            return result;
        }
    }
}
