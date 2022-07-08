namespace GameSystems.CharacterSystem.Enemy
{
    public class Elf: Enemy
    {
        public override void PlayEffect()
        {
            Effect("ElfHitEffect");
        }
    }
}