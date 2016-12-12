using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Components
{
    public class Animation
    {

        public Texture2D[] Textures { get; set; }

        public int TimeBetweenFrames { get; set; }


        public Animation(Texture2D[] textures, int timeBetweenFrames)
        {
            Textures = textures;
            TimeBetweenFrames = timeBetweenFrames;
        }

        public Animation(int timeBetweenFrames)
        {
            TimeBetweenFrames = timeBetweenFrames;
        }
    }
}
