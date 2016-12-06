using Artemis.System;
using System;
using Artemis;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework.Graphics;
using Artemis.Attributes;
using Artemis.Manager;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace DungeonWanderer.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 0)]
    public class RenderingSystem : EntityComponentProcessingSystem<TransformComponent, RenderingComponent>
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;
        private CameraComponent camera;
        public RenderingSystem(CameraComponent camera, SpriteBatch batch, GraphicsDevice device)
        {
            spriteBatch = batch;
            graphicsDevice = device;
            this.camera = camera;
        }
        public override void Process(Entity entity, TransformComponent transformComponent, RenderingComponent renderingComponent)
        {
            Vector2 dimension = transformComponent.Dimension * camera.ScalingFactor;

            Vector2 rotationOrigin = new Vector2(dimension.X/2,dimension.Y / 2);

            Vector2 renderingPosition = new Vector2(1, -1) * transformComponent.Position * camera.ScalingFactor + camera.BitmapPosition;

            spriteBatch.Draw(
                 renderingComponent.Texture,
                 renderingPosition,
                 null,
                 Color.White,
                 -transformComponent.Rotation,
                 new Vector2(
                     renderingComponent.Texture.Width / 2,
                     renderingComponent.Texture.Height / 2),
                 new Vector2(dimension.X / renderingComponent.Texture.Width, dimension.Y / renderingComponent.Texture.Height),
                 SpriteEffects.None,
                 renderingComponent.Z);
        }
    }
}
