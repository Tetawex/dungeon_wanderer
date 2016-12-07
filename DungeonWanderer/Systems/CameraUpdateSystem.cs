using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using DungeonWanderer.Components;
using Artemis;
using Microsoft.Xna.Framework;

namespace DungeonWanderer.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    public class CameraUpdateSystem : EntityComponentProcessingSystem<CameraComponent, TransformComponent>
    {
        private GraphicsDeviceManager graphics;

        public CameraUpdateSystem(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
        }

        public override void Process(Entity entity, CameraComponent cameraComponent, TransformComponent transformComponent)
        {
            cameraComponent.BitmapPosition = new Vector2(-transformComponent.Position.X * cameraComponent.ScalingFactor
                + graphics.PreferredBackBufferWidth / 2, transformComponent.Position.Y * cameraComponent.ScalingFactor
                + graphics.PreferredBackBufferHeight / 2);
        }
    }
}
