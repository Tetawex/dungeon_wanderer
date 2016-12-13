﻿using Artemis.Interface;
using System.Diagnostics;

namespace DungeonWanderer.Components
{
    class AnimationComponent : IComponent
    {
        public Stopwatch sw = new Stopwatch();
        public int CurrentFrame { get; set; }

        public Animation Animation { get; set; }

        public AnimationComponent(Animation animation)
        {
            Animation = animation;
        }


    }
}