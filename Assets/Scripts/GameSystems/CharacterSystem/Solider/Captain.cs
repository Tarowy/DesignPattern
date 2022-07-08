namespace GameSystems.CharacterSystem.Solider
{
    public class Captain: Solider
    {
        public override void PlayEffect()
        {
            Effect("CaptainDeadEffect");
        }

        public override void PlaySound()
        {
            Sound("CaptainDeath");
        }
    }
}