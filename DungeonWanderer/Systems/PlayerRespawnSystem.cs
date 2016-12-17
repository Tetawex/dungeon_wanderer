using Artemis.System;
using DungeonWanderer.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using DungeonWanderer.Core;
using Microsoft.Xna.Framework;

namespace DungeonWanderer.Systems
{
    public class PlayerRespawnSystem : EntityComponentProcessingSystem<HealthComponent,PhysicsComponent>
    {
        private DWGame game;
        private Vector2 respawnPosition;
        public PlayerRespawnSystem(DWGame game, Vector2 respawnPosition)
        {
            this.game = game;
            this.respawnPosition = respawnPosition;
        }

        public override void Process(Entity entity, HealthComponent healthComponent,PhysicsComponent physicsComponent)
        {
            if (physicsComponent.Body.Position.Y <= -40f)
                healthComponent.Health = 0;
            if (healthComponent.Health <= 0)
            {
                if (--healthComponent.Lives == 0)
                    game.GameStateManager.CurrentState = GameState.GameOverLost;
                else
                {
                    physicsComponent.Body.Position = respawnPosition;
                    physicsComponent.Body.LinearVelocity = Vector2.Zero;
                    healthComponent.Health = 100;
                }
            }
        }
    }
}
