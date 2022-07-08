namespace GameSystems.CharacterSystem.Enemy
{
    public class Ogre: Enemy
    {
        public override void PlayEffect()
        {
            Effect("OgreHitEffect");
        }
    }
}