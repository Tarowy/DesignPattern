namespace GameSystems.CharacterSystem.Solider
{
    public class Sergeant: Solider

    {
        public override void PlayEffect()
        {
            Effect("SergeantDeadEffect");
        }

        public override void PlaySound()
        {
            Sound("SergeantDeath");
        }
    }
}