using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Threading;

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

            if (animComp.sw.IsRunning)
                animComp.sw.Start();

            if (animComp.sw.ElapsedMilliseconds > animComp.Animation.TimeBetweenFrames)
            {
                renComp.Texture = animComp.Animation.Textures[animComp.CurrentFrame];

                if (animComp.CurrentFrame < animComp.Animation.Textures.Length)
                    animComp.CurrentFrame++;
                else
                    animComp.CurrentFrame = animComp.CurrentFrame++ % animComp.Animation.Textures.Length;

                animComp.sw.Reset();
            }
           
        }
    }
}
