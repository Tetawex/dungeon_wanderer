using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using DungeonWanderer.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonWanderer.Systems
{
    public class PlayerControllerSystem : EntityComponentProcessingSystem<PhysicsComponent, PlayerControllerComponent, JumpComponent,RenderingComponent,AnimationComponent>
    {
        private AnimationManager animationManager;
        public PlayerControllerSystem(AnimationManager manager)
        {
            animationManager = manager;
        }
        public override void Process(Entity entity, PhysicsComponent physicsComponent, 
            PlayerControllerComponent playerControllerComponent, JumpComponent jumpComponent, 
            RenderingComponent renderingComponent,AnimationComponent animationComponent)
        {
            //TODO Make controls feel more responsive and less sloppy
            if (Keyboard.GetState().IsKeyDown(Keys.Left)
                &&physicsComponent.Body.LinearVelocity.X>-5f)
            {
                physicsComponent.Body.Friction = 0.1f;
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(-0.3f, 0f));
                animationComponent.Animation = animationManager.GetAnimation("player_run");
                renderingComponent.InvertHorizonatally = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) &&
                physicsComponent.Body.LinearVelocity.X < 5f)
            {
                physicsComponent.Body.Friction = 0.1f;
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0.3f, 0f));
                animationComponent.Animation = animationManager.GetAnimation("player_run");
                renderingComponent.InvertHorizonatally = false;
            }
            else
            {
                physicsComponent.Body.Friction = 4.0f;
                animationComponent.Animation = animationManager.GetAnimation("player_stay");
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Space) ||
                Keyboard.GetState().IsKeyDown(Keys.Up)) && jumpComponent.Grounded)
            {
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0f, 6f));
            }
            if(!jumpComponent.Grounded)
                animationComponent.Animation = animationManager.GetAnimation("player_fly");
        }
    }
}
