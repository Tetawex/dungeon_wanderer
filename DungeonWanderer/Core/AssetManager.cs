﻿using Microsoft.Xna.Framework.Content;
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
}
