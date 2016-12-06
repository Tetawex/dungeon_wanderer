
using System;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Artemis;
using DungeonWanderer.Components;
using DungeonWanderer.Systems;
using Artemis.Manager;
using DungeonWanderer.Templates;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Core
{
    public class MainMenuScreen: Screen
    {
        private EntityWorld entityWorld;

        public MainMenuScreen(DWGame dwgame) : base(dwgame)
        {
        }

        public override void Draw(GameTime gametime)
        {
            spriteBatch.Begin();

            entityWorld.Draw();

            spriteBatch.End();
        }

        public override void Initialize()
        {
            entityWorld = new EntityWorld();
            //TODO: Implement UI systems and components, load UI data from a json file
        }

        public override void Update(GameTime gametime)
        {
            entityWorld.Update();
        }
    }
}
