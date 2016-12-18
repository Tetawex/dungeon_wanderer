using Artemis;
using Artemis.Interface;
using DungeonWanderer.Components;
using DungeonWanderer.Core;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.Templates
{
    public class SpikeTemplate : IEntityTemplate
    {
        public static string Name { get; internal set; } = "SpikeTemplate";

        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            //args:0position,1box2DWorld,2rotation,3player,4texture
            Vector2 position = (Vector2)args[0];
            World box2DWorld = (World)args[1];
            float rotation = Convert.ToSingle(args[2]);
            Entity player=(Entity)args[3];
            Body body = new Body(box2DWorld, Vector2.Zero);
            Body pBody = player.GetComponent<PhysicsComponent>().Body;

            body.CreateFixture(ShapeFactory.GetShape(new Vector2(0.25f,0.25f)))
            .OnCollision += (f1, f2, contact) =>
                {
                    if (f2.Body == pBody || f1.Body == pBody)
                    {
                        player.GetComponent<HealthComponent>().Health = 0;
                        BasicAudioPlayer.PlaySound("sound_hit");
                    }
                    return true;
                }; ;
            body.Friction = 0.1f;

            body.FixedRotation = true;
            //body.CollisionGroup = MovementSystem.COLLISION_GROUP_TERRAIN;
            body.BodyType = BodyType.Static;
            box2DWorld.BodyList.Add(body);
            body.Rotation = rotation;
            body.Position = position;

            entity.AddComponent<TransformComponent>(new TransformComponent(position, new Vector2(1f, 1f)));
            entity.AddComponent<PhysicsComponent>(new PhysicsComponent(body));
            entity.AddComponent<RenderingComponent>(new RenderingComponent((Texture2D)args[4],0f));

            return entity;
        }
    }
}
