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
            textures["terrainbox"] = contentManager.Load<Texture2D>("terrainbox");
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
            animations["player_move"] = new Animation(new Texture2D[] 
            {
                textureManager.GetTexture("player_move_0"),
                textureManager.GetTexture("player_move_1")
            });
            animations["player_fly"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_fly_0"),
                textureManager.GetTexture("player_fly_1")
            });
            animations["player_stay"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_stay_0"),
                textureManager.GetTexture("player_stay_1")
            });
        }
    }
}
