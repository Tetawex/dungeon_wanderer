using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.Components
{
    public class HealthComponent : IComponent
    {
        public int Health { get; set; }
        public int Lives { get; set; }
        public HealthComponent()
        {
            Health = 100;
            Lives = 3;
        }
    }
}
