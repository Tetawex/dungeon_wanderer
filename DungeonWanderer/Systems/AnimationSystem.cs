﻿using Artemis;
using Artemis.System;
using DungeonWanderer.Components;
using DungeonWanderer.Core;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace DungeonWanderer.Systems
{
    public class AnimationSystem : IntervalEntityProcessingSystem
    {
        private AnimationManager animationManager;
        public AnimationSystem(AnimationManager animationManager) :
            base(new TimeSpan(0, 0, 0, 0, 100), Aspect.All(typeof(AnimationComponent), typeof(RenderingComponent)))
        {
            this.animationManager = animationManager;
        }
        public override void Process(Entity e)
        {

            AnimationComponent animComp = e.GetComponent<AnimationComponent>();
            RenderingComponent renComp = e.GetComponent<RenderingComponent>();

            //if (animComp.sw.IsRunning)
            //    animComp.sw.Start();

            //if (animComp.sw.ElapsedMilliseconds > animComp.Animation.TimeBetweenFrames)
            //{

            //renComp.Texture = animComp.Animation.Textures[animComp.CurrentFrame++];
           // animComp.CurrentFrame++;
            if (animComp.CurrentFrame >= animComp.Animation.Textures.Length)
                animComp.CurrentFrame = 0;

           // else


            //    animComp.sw.Reset();
            //}
            //the code above doesn't really work for some reason, so here's my own:
            if (++animComp.ElapsedTicksBeforeNextFrame > animComp.Animation.TimeBetweenFrames)//increment means increment first, then tell the value
            {
                animComp.ElapsedTicksBeforeNextFrame = 0;
                renComp.Texture = animComp.Animation.Textures[animComp.CurrentFrame];
                if (++animComp.CurrentFrame >= animComp.Animation.Textures.Length)
                {
                    animComp.CurrentFrame = 0;
                }
            }
        }
    }
}
