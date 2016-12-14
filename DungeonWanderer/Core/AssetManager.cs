using DungeonWanderer.Components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace DungeonWanderer.Core
{
    public class AssetManager
    {
        public TextureManager TextureManager { get; private set; } = new TextureManager();
        public AnimationManager AnimationManager { get; private set; } = new AnimationManager();
    }
    public class TextureManager
    {
        private Dictionary<String,Texture2D> textures = new Dictionary<String,Texture2D>();
        public Texture2D GetTexture(String name)
        {
            return textures[name];
        }
        public void LoadContent(ContentManager contentManager)
        {
            textures["playerbox"] = contentManager.Load<Texture2D>("playerbox");
            textures["background"] = contentManager.Load<Texture2D>("background");

            textures["player_stay_0"] = contentManager.Load<Texture2D>("player_stay_0");
            textures["player_stay_1"] = contentManager.Load<Texture2D>("player_stay_1");

            textures["wall_4x1"] = contentManager.Load<Texture2D>("wall_4x1");
            textures["wall_3x1"] = contentManager.Load<Texture2D>("wall_3x1");
            textures["wall_2x1"] = contentManager.Load<Texture2D>("wall_2x1");
            textures["wall_1x1"] = contentManager.Load<Texture2D>("wall_1x1");

            textures["wall_4x2"] = contentManager.Load<Texture2D>("wall_4x2");
            textures["wall_3x2"] = contentManager.Load<Texture2D>("wall_3x2");
            textures["wall_2x2"] = contentManager.Load<Texture2D>("wall_2x2");
            textures["wall_1x2"] = contentManager.Load<Texture2D>("wall_1x2");

            textures["wall_4x4"] = contentManager.Load<Texture2D>("wall_4x4");
            textures["wall_3x4"] = contentManager.Load<Texture2D>("wall_3x4");
            textures["wall_2x4"] = contentManager.Load<Texture2D>("wall_2x4");
            textures["wall_1x4"] = contentManager.Load<Texture2D>("wall_1x4");

            textures["column"] = contentManager.Load<Texture2D>("column");
            textures["background_2x2"] = contentManager.Load<Texture2D>("background_2x2");
            textures["background_3x3"] = contentManager.Load<Texture2D>("background_3x3");
            textures["background_4x4"] = contentManager.Load<Texture2D>("background_4x4");
        }
        public void UnloadContent()
        {
            foreach(KeyValuePair<string, Texture2D> pair in textures)
            {
                pair.Value.Dispose();
            }
        }
    }
    public class AnimationManager
    {
        private Dictionary<String, Animation> animations = new Dictionary<String, Animation>();
        public Animation GetAnimation(String name)
        {
            return animations[name];
        }
        public void LoadAnimations(TextureManager textureManager)
        {
            animations["player_stay"] = new Animation(new Texture2D[] 
            {
                textureManager.GetTexture("player_stay_0"),
                textureManager.GetTexture("player_stay_1")
            },50);
            /*animations["player_fly"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_fly_0"),
                textureManager.GetTexture("player_fly_1")
            },700);
            animations["player_stay"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_stay_0"),
                textureManager.GetTexture("player_stay_1")
            },700);*/
        }
    }
}
