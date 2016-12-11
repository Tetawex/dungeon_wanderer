using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using System;


namespace DungeonWanderer.Systems
{
    class AnimationSystem : IntervalEntityProcessingSystem
    {
        public AnimationSystem() :
            base(new TimeSpan(0, 0, 0, 0, 1), Aspect.All(typeof(AnimationComponent), typeof(RenderingComponent)))
        {

        }
        public override void Process(Entity e)
        {
            AnimationComponent animComp = e.GetComponent<AnimationComponent>();
            RenderingComponent renComp = e.GetComponent<RenderingComponent>();

            renComp.Texture = animComp.Animation.Textures[animComp.CurrentFrame];

            if (animComp.CurrentFrame < animComp.Animation.Textures.Length)
                animComp.CurrentFrame++;
            else
                animComp.CurrentFrame = animComp.CurrentFrame++ % animComp.Animation.Textures.Length;

        }
    }
}
