using System;
using Artemis;
using Artemis.Interface;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using System.Collections.Generic;
using FarseerPhysics.Collision.Shapes;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework.Graphics;
using DungeonWanderer.Core;

namespace DungeonWanderer.Templates
{
    public class PlatformTemplate : IEntityTemplate
    {
        public static string Name { get; internal set; } = "PlatformTemplate";

        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            //args:1position,2box2DWorld,3rotation,4dimensions,5rotationSpeed
            Vector2 position = (Vector2)args[0];
            World box2DWorld = (World)args[1];
            float rotation = Convert.ToSingle(args[3]);
            float rotationSpeed = Convert.ToSingle(args[5]);
            Body body = new Body(box2DWorld, Vector2.Zero);

            body.CreateFixture(ShapeFactory.GetShape((Vector2)(args[4])));
            body.Friction = 0.1f;

            body.FixedRotation = true;
            //body.CollisionGroup = MovementSystem.COLLISION_GROUP_TERRAIN;
            body.BodyType = BodyType.Static;
            box2DWorld.BodyList.Add(body);
            body.Rotation = rotation;
            body.Position = position;

            entity.AddComponent<TransformComponent>(new TransformComponent(position, new Vector2(4f, 1f)));
            entity.AddComponent<PhysicsComponent>(new PhysicsComponent(body));
            entity.AddComponent<RenderingComponent>(new RenderingComponent((Texture2D)args[2]));
            if(rotationSpeed!=0)
                entity.AddComponent<SelfRotatingPlatformComponent>(new SelfRotatingPlatformComponent());

            return entity;
        }
    }
}
