using DungeonWanderer.Components;
using DungeonWanderer.Core;
using System;

namespace DungeonWanderer
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AnimationComponent animComp = new AnimationComponent(new Animation(40));
            if (animComp.sw.IsRunning)
                animComp.sw.Start();

            if (animComp.sw.ElapsedTicks > animComp.Animation.TimeBetweenFrames)
            {
                Console.WriteLine("Ura");

                animComp.sw.Reset();
            }

                //using (var game = new DWGame())
                //game.Run();
        }
    }
}
