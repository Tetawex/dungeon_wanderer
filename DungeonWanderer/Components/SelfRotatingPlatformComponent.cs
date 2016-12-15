using Artemis.Interface;

namespace DungeonWanderer.Components
{
    public class SelfRotatingPlatformComponent : IComponent
    {
        public SelfRotatingPlatformComponent(float rotationSpeed)
        {
            RotationSpeed = rotationSpeed;
        }

        public float RotationSpeed { get; set; }
    }
}
