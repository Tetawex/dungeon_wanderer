using Artemis.System;
using DungeonWanderer.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace DungeonWanderer.Systems
{
    public class SelfRotatingPlatformtSystem : EntityComponentProcessingSystem<SelfRotatingPlatformComponent, PhysicsComponent>
    {
        public override void Process(Entity entity, SelfRotatingPlatformComponent component1, PhysicsComponent component2)
        {
            component2.Body.Rotation += 0.005f;
        }
    }
}
