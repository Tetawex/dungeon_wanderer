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
            //args:0position,1box2DWorld,2textureManager,3rotation,4dimension,5rotationSpeed
            Vector2 position = (Vector2)args[0];
            World box2DWorld = (World)args[1];
            TextureManager tm = (TextureManager)args[2];
            float rotation = Convert.ToSingle(args[3]);
            Vector2 dimension = (Vector2)(args[4]);
            float rotationSpeed = Convert.ToSingle(args[5]);
            Body body = new Body(box2DWorld, Vector2.Zero);

            body.CreateFixture(ShapeFactory.GetShape(dimension));
            body.Friction = 0.1f;

            body.FixedRotation = true;
            //body.CollisionGroup = MovementSystem.COLLISION_GROUP_TERRAIN;
            body.BodyType = BodyType.Static;
            box2DWorld.BodyList.Add(body);
            body.Rotation = rotation;
            body.Position = position;

            entity.AddComponent<TransformComponent>(new TransformComponent(position, dimension));
            entity.AddComponent<PhysicsComponent>(new PhysicsComponent(body));
            entity.AddComponent<RenderingComponent>(new RenderingComponent(tm.GetTexture("wall_"+(int)dimension.X + "x" + (int)dimension.Y),0.1f));
            if(rotationSpeed!=0)
                entity.AddComponent<SelfRotatingPlatformComponent>(new SelfRotatingPlatformComponent(rotationSpeed));

            return entity;
        }
    }
}
