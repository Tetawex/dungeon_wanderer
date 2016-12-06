using Artemis;
using Artemis.System;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using DungeonWanderer.Components;

namespace DungeonWanderer.Systems
{
    public class MovementSystem : EntityComponentProcessingSystem<PositionComponent,PhysicsComponent>
    {
        private World world;
        public MovementSystem()
        {
            world = new World(new Vector2(0f, 9.82f));
        }
        public override void Process(Entity entity, PositionComponent movementComponent,PhysicsComponent physicsComponent)
        {
            movementComponent.Position = physicsComponent.Body.Position;
        }
        public void Step(float deltaTime)
        {
            world.Step(deltaTime);
        }
    }
}
