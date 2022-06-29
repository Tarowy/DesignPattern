namespace GameSystems.CharacterSystem.AttrStrategy
{
    public class SoliderAttrStrategy: IAttrStrategy
    {
        public int GetExtraHp(int level) => (level - 1) * 10;

        public int GetDamageReduceValue(int level) => (level - 1) * 5;

        public int GetCriticalDamage(int criticalRate) => 0;
    }
}