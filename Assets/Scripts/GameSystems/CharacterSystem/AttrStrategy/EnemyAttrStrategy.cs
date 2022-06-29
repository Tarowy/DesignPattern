using UnityEngine;

namespace GameSystems.CharacterSystem.AttrStrategy
{
    public class EnemyAttrStrategy: IAttrStrategy
    {
        public int GetExtraHp(int level) => 0;

        public int GetDamageReduceValue(int level) => 0;

        public int GetCriticalDamage(int criticalRate)
        {
            return Random.Range(0, 1f) <= criticalRate 
                ? (int) (Random.Range(0.5f, 1f) * 10) : 0;
        }
    }
}