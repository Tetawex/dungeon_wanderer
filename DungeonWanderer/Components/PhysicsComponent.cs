using Artemis.Interface;
using FarseerPhysics.Dynamics;

namespace DungeonWanderer.Components
{
    public class PhysicsComponent : IComponent
    {
        public Body Body { get; set; }
        public PhysicsComponent(Body body)
        {
            Body = body;
        }
    }
}
