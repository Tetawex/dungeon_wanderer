using Artemis.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonWanderer.Components
{
    public class RenderingComponent : IComponent
    {
        public Texture2D Texture { get; set; }
        public float Z { get; set; } = 1.0f;
        public RenderingComponent(Texture2D  texture)
        {
            Texture = texture;
        }
        public RenderingComponent(Texture2D texture,float z)
        {
            Texture = texture;
            Z = z;
        }
    }
}
