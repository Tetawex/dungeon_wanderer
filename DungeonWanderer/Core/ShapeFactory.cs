using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace DungeonWanderer.Core
{
    public class ShapeFactory
    {
        public static Shape GetShape(Vector2 dimension)
        {
            return new PolygonShape(new Vertices(new List<Vector2>()
            {
                new Vector2(-dimension.X/2f, -dimension.Y/2f),
                new Vector2(-dimension.X/2f, dimension.Y/2f),
                new Vector2(dimension.X/2f, dimension.Y/2f),
                new Vector2(dimension.X/2f, -dimension.Y/2f)
            }), 1f);
        }
    }
}
