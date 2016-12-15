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
    public class LevelEndTemplate : IEntityTemplate
    {
        public static string Name { get; internal set; } = "LevelEndTemplate";

        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            //args:0position,1box2DWorld,2texture,3player,4gameScreen,5game
            Vector2 position = (Vector2)args[0];
            World box2DWorld = (World)args[1];
            Entity player=(Entity)args[3];
            GameScreen gs= (GameScreen)args[4];
            DWGame game = (DWGame)args[5];
            Body body = new Body(box2DWorld, Vector2.Zero);

            body.CreateFixture(ShapeFactory.GetShape(new Vector2(0.75f,0.75f)))
            .OnCollision += (f1, f2, contact) =>
                {
                    if (++gs.CurrentLevel > 2 || gs.CurrentLevel < 0)
                        game.GameStateManager.CurrentState = GameState.MainMenu;
                    else
                        gs.Initialize();
                    return true;
                }; ;
            body.Friction = 0.1f;

            body.FixedRotation = true;
            //body.CollisionGroup = MovementSystem.COLLISION_GROUP_TERRAIN;
            body.BodyType = BodyType.Static;
            box2DWorld.BodyList.Add(body);
            body.Position = position;

            entity.AddComponent<TransformComponent>(new TransformComponent(position, new Vector2(1f, 1f)));
            entity.AddComponent<PhysicsComponent>(new PhysicsComponent(body));
            entity.AddComponent<RenderingComponent>(new RenderingComponent((Texture2D)args[2],1f));

            return entity;
        }
    }
}
