using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.JSON
{
    public class Spike
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Rotation { get; set; }
    }

    public class Wall
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float DimX { get; set; }
        public float DimY { get; set; }
        public float Rotation { get; set; }
        public float RotationSpeed { get; set; }
    }

    public class LevelModel
    {
        public float StartX { get; set; }
        public float StartY { get; set; }
        public float EndX { get; set; }
        public float EndY { get; set; }
        public IList<Spike> Spikes { get; set; }
        public IList<Wall> Walls { get; set; }
    }
}
