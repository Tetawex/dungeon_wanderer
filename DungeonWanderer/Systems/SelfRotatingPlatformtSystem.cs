using Artemis.System;
using DungeonWanderer.Components;
using Artemis;

namespace DungeonWanderer.Systems
{
    //This system is only for testing purposes and won't make it to the release at its current state
    public class SelfRotatingPlatformtSystem : EntityComponentProcessingSystem<SelfRotatingPlatformComponent, PhysicsComponent>
    {
        public override void Process(Entity entity, SelfRotatingPlatformComponent component1, PhysicsComponent component2)
        {
            component2.Body.Rotation += 0.005f;
        }
    }
}
