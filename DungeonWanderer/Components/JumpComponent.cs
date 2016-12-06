using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.Components
{
    public class JumpComponent : IComponent
    {
        public bool Grounded { get; set; }
    }
}
