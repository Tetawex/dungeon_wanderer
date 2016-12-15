using Artemis.System;
using Artemis;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework.Graphics;
using Artemis.Attributes;
using Artemis.Manager;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace DungeonWanderer.Systems
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 0)]
    public class HUDRenderingSystem : EntityComponentProcessingSystem<HealthComponent>
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        public HUDRenderingSystem(Texture2D texture, SpriteBatch batch)
        {
            spriteBatch = batch;
            this.texture = texture;
        }
        public override void Process(Entity entity, HealthComponent hc)
        {
            for(int i=0;i<hc.Lives;i++)
                spriteBatch.Draw(
                 texture,
                 new Vector2(16+i*54,16));
        }
    }
}
