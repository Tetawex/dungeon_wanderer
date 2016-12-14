using Artemis.Interface;
using System.Diagnostics;

namespace DungeonWanderer.Components
{
    public class AnimationComponent : IComponent
    {        
        public int CurrentFrame { get; set; }
        public int ElapsedTicksBeforeNextFrame { get; set; }
        public Animation Animation { get; set; }

        public AnimationComponent(Animation animation)
        {
            Animation = animation;
        }


    }
}
