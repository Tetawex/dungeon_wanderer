using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonWanderer.Systems
{
    public class PlayerControllerSystem : EntityComponentProcessingSystem<PhysicsComponent, PlayerControllerComponent, JumpComponent,RenderingComponent>
    {
        public PlayerControllerSystem()
        {

        }
        public override void Process(Entity entity, PhysicsComponent physicsComponent, 
            PlayerControllerComponent playerControllerComponent, JumpComponent jumpComponent, RenderingComponent renderingComponent)
        {
            //TODO Make controls feel more responsive and less sloppy
            physicsComponent.Body.Friction = 4.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)
                &&physicsComponent.Body.LinearVelocity.X>-5f)
            {
                physicsComponent.Body.Friction = 0.1f;
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(-0.3f, 0f));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) &&
                physicsComponent.Body.LinearVelocity.X < 5f)
            {
                physicsComponent.Body.Friction = 0.1f;
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0.3f, 0f));
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Space)|| 
                Keyboard.GetState().IsKeyDown(Keys.Up) )&& jumpComponent.Grounded)
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0f, 6f));
        }
    }
}
