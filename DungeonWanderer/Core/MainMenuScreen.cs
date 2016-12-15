using Microsoft.Xna.Framework;
using Artemis;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Core
{
    public class MainMenuScreen: Screen
    {
        private Rectangle _btnPlay;
        private Rectangle _btnQuit;
        private Texture2D _texPlay;
        private Texture2D _texQuit;
        private Texture2D _bckTex;

        public MainMenuScreen(DWGame dwgame) : base(dwgame)
        {
        }

        public override void Draw(GameTime gametime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_bckTex, new Vector2(0, 0));
            spriteBatch.Draw(_texPlay,null, _btnPlay);
            spriteBatch.Draw(_texQuit, null, _btnQuit);
            spriteBatch.End();
        }

        public override void Initialize()
        {
            _btnPlay = new Rectangle(1280/2-128, 256, 256, 64);
            _btnQuit = new Rectangle(1280/2- 128, 720-256, 256, 64);
            _texPlay = game.AssetManager.TextureManager.GetTexture("btnPlay");
            _texQuit = game.AssetManager.TextureManager.GetTexture("btnQuit");
            _bckTex = game.AssetManager.TextureManager.GetTexture("background");
        }

        public override void Update(GameTime gametime)
        {
            MouseState state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed)
            {
                if (_btnPlay.Contains(state.Position))
                {
                    game.GameStateManager.CurrentState = GameState.Game;
                }
                else if (_btnQuit.Contains(state.Position))
                {
                    game.Exit();
                }
            }
        }
    }
}
