namespace GameSystems.CharacterSystem.Enemy
{
    public class Troll: Enemy
    {
        public override void PlayEffect()
        {
            Effect("TrollHitEffect");
        }
    }
}