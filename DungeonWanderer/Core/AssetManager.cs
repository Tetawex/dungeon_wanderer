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
            //textures["playerbox"] = contentManager.Load<Texture2D>("playerbox");
            textures["btnPlay"] = contentManager.Load<Texture2D>("btnPlay");
            textures["btnQuit"] = contentManager.Load<Texture2D>("btnQuit");
            textures["btnCustom"] = contentManager.Load<Texture2D>("btnCustom");
            textures["background"] = contentManager.Load<Texture2D>("background");
            textures["loseTex"] = contentManager.Load<Texture2D>("loseTex");
            textures["winTex"] = contentManager.Load<Texture2D>("winTex");
            textures["heart"] = contentManager.Load<Texture2D>("heart");
            textures["treasure"] = contentManager.Load<Texture2D>("treasure");
            textures["spike"] = contentManager.Load<Texture2D>("spike_top");

            textures["player_stay"] = contentManager.Load<Texture2D>("player_stay");

            textures["player_run_0"] = contentManager.Load<Texture2D>("player_run_0");
            textures["player_run_1"] = contentManager.Load<Texture2D>("player_run_1");
            textures["player_run_2"] = contentManager.Load<Texture2D>("player_run_2");
            textures["player_run_3"] = contentManager.Load<Texture2D>("player_run_3");
            textures["player_run_4"] = contentManager.Load<Texture2D>("player_run_4");
            textures["player_run_5"] = contentManager.Load<Texture2D>("player_run_5");
            textures["player_run_6"] = contentManager.Load<Texture2D>("player_run_6");
            textures["player_run_7"] = contentManager.Load<Texture2D>("player_run_7");
            textures["player_run_8"] = contentManager.Load<Texture2D>("player_run_8");
            textures["player_run_9"] = contentManager.Load<Texture2D>("player_run_9");
            textures["player_run_10"] = contentManager.Load<Texture2D>("player_run_10");
            textures["player_run_11"] = contentManager.Load<Texture2D>("player_run_11");
            textures["player_run_12"] = contentManager.Load<Texture2D>("player_run_12");

            textures["player_fly"] = contentManager.Load<Texture2D>("player_fly");
            


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

            textures["wall_1x3"] = contentManager.Load<Texture2D>("column");
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
                textureManager.GetTexture("player_stay"),
                
            });

            animations["player_fly"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_fly")
            });

            animations["player_run"] = new Animation(new Texture2D[]
            {
                textureManager.GetTexture("player_run_0"),
                textureManager.GetTexture("player_run_1"),
                textureManager.GetTexture("player_run_2"),
                textureManager.GetTexture("player_run_3")
            });
        }
    }
}
