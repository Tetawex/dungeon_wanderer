using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Core
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DWGame : Game
    {
        public AssetManager AssetManager { get; private set; }
        public GameStateManager GameStateManager { get; private set; }

        public GraphicsDeviceManager Graphics { get; private set; }

        public DWGame()
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferHeight = 720,
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferFormat = SurfaceFormat.Color,
                PreferMultiSampling = false,
                PreferredDepthStencilFormat = DepthFormat.None
            };
            IsMouseVisible = true;
            Graphics.SynchronizeWithVerticalRetrace = false;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            AssetManager = new AssetManager();
            GameStateManager = new GameStateManager(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            AssetManager.TextureManager.LoadContent(Content);
            AssetManager.AnimationManager.LoadAnimations(AssetManager.TextureManager);
            BasicAudioPlayer.Initialize(Content);
            GameStateManager.CurrentState = GameState.MainMenu;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GameStateManager.CurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            GameStateManager.CurrentScreen.Draw(gameTime);

            base.Draw(gameTime);


        }
    }
}
