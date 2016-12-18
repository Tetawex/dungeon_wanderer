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
        private bool jumpPressed = false;
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
            if (!Keyboard.GetState().IsKeyDown(Keys.Space)) jumpPressed = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Space)  && jumpComponent.Grounded&&jumpPressed==false)
            {
                jumpPressed = true;
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0f, 12.5f));
                BasicAudioPlayer.PlaySound("sound_jump");
            }
            if(!jumpComponent.Grounded)
                animationComponent.Animation = animationManager.GetAnimation("player_fly");
        }
    }
}
