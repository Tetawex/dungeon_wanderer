using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWanderer.Core
{
    public abstract class Screen
    {
        protected DWGame game;
        protected SpriteBatch spriteBatch;

        public Screen(DWGame dwgame)
        {
            game = dwgame;
            spriteBatch = new SpriteBatch(dwgame.GraphicsDevice);
        }

        public abstract void Initialize();
        public abstract void Update(GameTime gametime);
        public abstract void Draw(GameTime gametime);
    }
}
