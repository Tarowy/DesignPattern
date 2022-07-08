namespace GameSystems.CharacterSystem.Solider
{
    public class Rookie: Solider
    {
        public override void PlayEffect()
        {
            Effect("RookieDeadEffect");
        }

        public override void PlaySound()
        {
            Sound("RookieDeath");
        }
    }
}