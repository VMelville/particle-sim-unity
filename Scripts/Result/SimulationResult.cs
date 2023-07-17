using System.Collections.Generic;

namespace ParticleSim.Result
{
    public class SimulationResult
    {
        public readonly List<Trajectory> Trajectories = new List<Trajectory>();
        public readonly Dictionary<int, List<(float, float)>> Senses = new Dictionary<int, List<(float, float)>>();
        public readonly List<LinerTrajectory> LinearTrajectory = new List<LinerTrajectory>();
    }
}
