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

namespace DungeonWanderer.Templates
{
    public class BasicTerrainTemplate : IEntityTemplate
    {
        public static string Name { get; internal set; } = "BasicTerrainTemplate";

        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            Vector2 position = (Vector2)args[0];
            World box2DWorld = (World)args[1];
            float rotation = Convert.ToSingle(args[3]);
            Body body = new Body(box2DWorld, Vector2.Zero);
            PolygonShape polygon = new PolygonShape(new Vertices(new List<Vector2>()
            {
                new Vector2(-2f, -0.5f),
                new Vector2(-2f, 0.5f),
                new Vector2(2f, 0.5f),
                new Vector2(2f, -0.5f)
            }), 1f);

            body.CreateFixture(polygon);
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

            return entity;
        }
    }
}
