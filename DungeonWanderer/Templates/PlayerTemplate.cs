using Artemis;
using Artemis.Interface;
using Artemis.System;
using DungeonWanderer.Components;
using DungeonWanderer.Systems;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace DungeonWanderer.Templates
{
    public class PlayerTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "PlayerTemplate";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.Group = "PLAYER";

            entityWorld.GroupManager.ToString();

            Vector2 position= (Vector2)args[0];

            JumpComponent jumpComponent = new JumpComponent();


            TransformComponent pc = new TransformComponent(position,new Vector2(1f, 1.5f));


            World box2DWorld = (World)args[1];
            Body body = new Body(box2DWorld);
            CircleShape circle = new CircleShape(0.5f,1f);
            circle.Position = new Vector2(0, 0.5f) - new Vector2(0, 1.5f * 0.5f);
            PolygonShape polygon = new PolygonShape(new Vertices(new List<Vector2>()
            {
                new Vector2(-0.5f, 0.5f)-new Vector2(0,1.5f*0.5f),
                new Vector2(-0.5f, 1.5f)-new Vector2(0,1.5f*0.5f),
                new Vector2(0.5f, 1.5f)-new Vector2(0,1.5f*0.5f),
                new Vector2(0.5f, 0.5f)-new Vector2(0,1.5f*0.5f)
            }),1f);
            body.CreateFixture(polygon);
            body.Friction = 0.1f;

            Fixture feet = body.CreateFixture(circle);
            feet.OnCollision+=(f1,f2,contact)=>
            {
                jumpComponent.Grounded = true;
                return true;
            };
            feet.OnSeparation += (f1, f2) =>
            {
                jumpComponent.Grounded = false;
            };
            body.FixedRotation = true;       
            //body.CollisionGroup = MovementSystem.COLLISION_GROUP_PLAYER;
            body.BodyType = BodyType.Dynamic;
            box2DWorld.BodyList.Add(body);

            body.Position = position;



            entity.AddComponent<TransformComponent>(pc);
            entity.AddComponent<PhysicsComponent>(new PhysicsComponent(body));
            entity.AddComponent<RenderingComponent>(new RenderingComponent((Texture2D)args[2]));
            entity.AddComponent<JumpComponent>(jumpComponent);
            entity.AddComponent<PlayerControllerComponent>(new PlayerControllerComponent());
            entity.AddComponent<CameraComponent>(new CameraComponent(new Vector2(0,0)));
            //entity.AddComponent<SelfRotatingPlatformComponent>(new SelfRotatingPlatformComponent());

            return entity;
        }
    }
}