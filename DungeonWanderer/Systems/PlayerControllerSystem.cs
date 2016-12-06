using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonWanderer.Systems
{
    public class PlayerControllerSystem : EntityComponentProcessingSystem<PhysicsComponent, PlayerControllerComponent, JumpComponent>
    {
        public PlayerControllerSystem()
        {

        }
        public override void Process(Entity entity, PhysicsComponent physicsComponent, 
            PlayerControllerComponent playerControllerComponent, JumpComponent jumpComponent)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(-0.1f, 0f));
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0.1f, 0f));
            if (Keyboard.GetState().IsKeyDown(Keys.Space)&&jumpComponent.Grounded)
                physicsComponent.Body.ApplyLinearImpulse(new Vector2(0f, 4f));
        }
    }
}
