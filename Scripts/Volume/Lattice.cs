using System;
using ParticleSim.CSGSolid;
using UnityEngine;

namespace ParticleSim.Volume
{
    public class Lattice : IPointerGettable
    {
        private IntPtr Ptr;

        public IntPtr GetPointer() => Ptr;

        // メモ　あくまで Lattice は中身が分割された LogicalVolume という感じ。基本的には LogicalVolume と同様の呼び方を想定
        // ToDo: 3重のPVReplicaを作成しているが、大抵の場合1～2回しか呼ばなくて済むはずなので、最適化したい
        public Lattice(Box solid, string name, string materialName, int x, int y, int z)
        {
            var motherCubeScale = solid.GetUnityCubeScale();
            var unitX = motherCubeScale.x / x;
            var unitY = motherCubeScale.y / y;
            var unitZ = motherCubeScale.z / z;
        
            var globalEnvelop = new LogicalVolume(solid, name, materialName);
        
            var xCubeScale = new Vector3(unitX, motherCubeScale.y, motherCubeScale.z);
            var xSolid = Box.CreateBoxFromUnityCubeScale(name, xCubeScale);
            var xVolume = new LogicalVolume(xSolid, name, materialName);
            _ = new PVReplica(name + "_X", xVolume, globalEnvelop, PVReplica.EAxis.kXAxis, x, unitX * 1000.0, 0.0); // ここでスケールの調整をやってるの、良くない
        
            var yCubeScale = new Vector3(unitX, unitY, motherCubeScale.z);
            var ySolid = Box.CreateBoxFromUnityCubeScale(name, yCubeScale);
            var yVolume = new LogicalVolume(ySolid, name, materialName);
            _ = new PVReplica(name + "_Y", yVolume, xVolume, PVReplica.EAxis.kYAxis, y, unitY * 1000.0, 0.0); // 同上

            var zCubeScale = new Vector3(unitX, unitY, unitZ);
            var zSolid = Box.CreateBoxFromUnityCubeScale(name, zCubeScale);
            var zVolume = new LogicalVolume(zSolid, name, materialName);
            _ = new PVReplica(name + "_Z", zVolume, yVolume, PVReplica.EAxis.kZAxis, z, unitZ * 1000.0, 0.0); // 同上

            Ptr = globalEnvelop.GetPointer();
        }
    }
}
