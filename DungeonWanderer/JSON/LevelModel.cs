using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.JSON
{
    public class Spike
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Rotation { get; set; }
    }

    public class Wall
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double DimX { get; set; }
        public double DimY { get; set; }
        public double Rotation { get; set; }
        public double RotationSpeed { get; set; }
    }

    public class LevelModel
    {
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public IList<Spike> Spikes { get; set; }
        public IList<Wall> Walls { get; set; }
    }
}
