using Artemis;
using FarseerPhysics.Dynamics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Newtonsoft.Json;
using DungeonWanderer.Core;

namespace DungeonWanderer.JSON
{
    public static class LevelLoader
    {
        public static LevelModel LoadLevel(String name)
        {
            using (StreamReader sr = new StreamReader("Content/"+name))
            {
                return JsonConvert.DeserializeObject<LevelModel>(sr.ReadToEnd());
            };
        }
    }
}
