﻿using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using DungeonWanderer.Components;
using FarseerPhysics.Dynamics;

namespace DungeonWanderer.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    public class MovementSystem : EntityComponentProcessingSystem<TransformComponent,PhysicsComponent>
    {
        public const short COLLISION_GROUP_PLAYER = 0x0001;
        public const short COLLISION_GROUP_TERRAIN = 0x0002;
        public const short COLLISION_GROUP_MONSTER = 0x0004;

        public MovementSystem(World box2DWorld)
        {
        }
        public override void Process(Entity entity, TransformComponent transformComponent,PhysicsComponent physicsComponent)
        {
            transformComponent.Position = physicsComponent.Body.Position;
            transformComponent.Rotation = physicsComponent.Body.Rotation;
        }
    }
}
