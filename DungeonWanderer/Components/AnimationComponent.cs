using Artemis.Interface;


namespace DungeonWanderer.Components
{
    class AnimationComponent : IComponent
    {
        public int CurrentFrame { get; set; }
        public Animation Animation { get; set; }

        public AnimationComponent(Animation animation)
        {
            Animation = animation;
        }


    }
}
