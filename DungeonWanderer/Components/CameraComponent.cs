using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace DungeonWanderer.Components
{
    public class CameraComponent : IComponent
    {
        public float ScalingFactor { get; set; } = 64f;
        public Vector2 BitmapPosition { get; set; }
        public CameraComponent(Vector2 position)
        {
            BitmapPosition = position;
        }
    }
}
