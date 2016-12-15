using Microsoft.Xna.Framework;
using Artemis;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Core
{
    public class GameOverScreen : Screen
    {
        private Texture2D _signTex;
        private Texture2D _bckTex;

        public GameOverScreen(DWGame dwgame,bool won) : base(dwgame)
        {
            if(won)
                _signTex = game.AssetManager.TextureManager.GetTexture("winTex");
            else
                _signTex = game.AssetManager.TextureManager.GetTexture("loseTex");
        }

        public override void Draw(GameTime gametime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_bckTex, new Vector2(0, 0));
            spriteBatch.Draw(_signTex, new Vector2(0, 0));
            spriteBatch.End();
        }

        public override void Initialize()
        {
            _bckTex = game.AssetManager.TextureManager.GetTexture("background");
        }

        public override void Update(GameTime gametime)
        {
            MouseState state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed)
            {
                    game.GameStateManager.CurrentState = GameState.MainMenu;
            }
        }
    }
}
