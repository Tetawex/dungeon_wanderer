using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Components
{
    class Animation
    {

        public Texture2D[] Textures { get; set; }

        // public int[] TimeBetweenFrames { get; set; }


        public Animation(Texture2D[] textures)
        {
            Textures = textures;
        }


    }
}
