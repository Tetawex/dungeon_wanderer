using System;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Artemis;
using DungeonWanderer.Components;
using DungeonWanderer.Systems;
using Artemis.Manager;
using DungeonWanderer.Templates;
using Microsoft.Xna.Framework.Graphics;
using DungeonWanderer.JSON;

namespace DungeonWanderer.Core
{
    public class GameScreen : Screen
    {
        private CameraComponent camera;
        private Texture2D background;
        private EntityWorld entityWorld;
        private World box2DWorld;
        public int CurrentLevel { get; set; } = 1;

        public GameScreen(DWGame dwgame) : base(dwgame)
        {
        }

        public override void Draw(GameTime gametime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null,SamplerState.PointClamp,
                null,null,null,null);
            spriteBatch.Draw(background,new Vector2(0,0));
            entityWorld.Draw();

            spriteBatch.End();
        }

        public override void Initialize()
        {
            LevelModel model = LevelLoader.LoadLevel("level" + CurrentLevel);

            box2DWorld = new World(new Vector2(0f, -9.82f));
            entityWorld = new EntityWorld();

            entityWorld.SystemManager.SetSystem<MovementSystem>(new MovementSystem(box2DWorld), GameLoopType.Update);
            entityWorld.SystemManager.SetSystem<CameraUpdateSystem>(new CameraUpdateSystem(game.Graphics), GameLoopType.Update);
            entityWorld.SystemManager.SetSystem<PlayerControllerSystem>(new PlayerControllerSystem(), GameLoopType.Update);
            entityWorld.SystemManager.SetSystem<SelfRotatingPlatformtSystem>(new SelfRotatingPlatformtSystem(), GameLoopType.Update);
            entityWorld.SystemManager.SetSystem<PlayerRespawnSystem>(new PlayerRespawnSystem(game, new Vector2(model.StartX, model.StartY)), GameLoopType.Update);

            entityWorld.SetEntityTemplate(PlayerTemplate.Name, new PlayerTemplate());
            entityWorld.SetEntityTemplate(PlatformTemplate.Name, new PlatformTemplate());
            entityWorld.SetEntityTemplate(SpikeTemplate.Name, new SpikeTemplate());
            entityWorld.SetEntityTemplate(LevelEndTemplate.Name, new LevelEndTemplate());

            Entity player=entityWorld.CreateEntityFromTemplate(PlayerTemplate.Name, new Vector2(model.StartX, model.StartY), box2DWorld, 
                game.AssetManager.TextureManager.GetTexture("playerbox"), game.AssetManager.AnimationManager.GetAnimation("player_stay"));

            entityWorld.CreateEntityFromTemplate(LevelEndTemplate.Name, new Vector2(model.EndX, model.EndY),
                box2DWorld, game.AssetManager.TextureManager.GetTexture("treasure"), player,this,game);
            foreach (Spike s in model.Spikes)
            {
                entityWorld.CreateEntityFromTemplate(SpikeTemplate.Name, new Vector2(s.X, s.Y),
                box2DWorld, s.Rotation, player, game.AssetManager.TextureManager.GetTexture("spike"));
            }
            foreach (Wall w in model.Walls)
            {
                entityWorld.CreateEntityFromTemplate(PlatformTemplate.Name, new Vector2(w.X, w.Y),
                box2DWorld, game.AssetManager.TextureManager, w.Rotation, new Vector2(w.DimX, w.DimY), w.RotationSpeed);
            }
            camera = player.GetComponent<CameraComponent>();

            entityWorld.SystemManager.SetSystem<RenderingSystem>(new RenderingSystem(camera, spriteBatch,game.GraphicsDevice), GameLoopType.Draw);
            entityWorld.SystemManager.SetSystem<HUDRenderingSystem>(
                new HUDRenderingSystem(game.AssetManager.TextureManager.GetTexture("heart"),spriteBatch), GameLoopType.Draw);
            entityWorld.SystemManager.SetSystem<AnimationSystem>(new AnimationSystem(game.AssetManager.AnimationManager), GameLoopType.Update);

            background = game.AssetManager.TextureManager.GetTexture("background");

            //TODO Imlement player respawn, health systems, obstacles and enemies spawn systems,
            //background /foreground static images,possibly tilemaps, scene loading from a json file

        }

        public override void Update(GameTime gameTime)
        {
            box2DWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            entityWorld.Update();
        }
    }
}
