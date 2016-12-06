using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace DungeonWanderer.Components
{
    public class TransformComponent  : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimension { get; set; }
        public float Rotation { get; set; }
        public Vector2 RenderingPosition
        {
            get { return new Vector2(Position.X - Dimension.X / 2, Position.Y + Dimension.Y /2); }
        }
        public TransformComponent()
        {
            Position = new Vector2(0f,0f);
        }
        public TransformComponent(float x, float y,float w,float h)
        {
            Position = new Vector2(x, y);
            Dimension = new Vector2(w, h);
        }
        public TransformComponent(Vector2 position,Vector2 dimension)
        {
            Position = position;
            Dimension = dimension;
        }
    }
}
