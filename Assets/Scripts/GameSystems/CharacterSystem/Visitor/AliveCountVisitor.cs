using UnityEngine;

namespace GameSystems.CharacterSystem.Visitor
{
    public class AliveCountVisitor : CharacterVisitor
    {
        public int EnemyLiveCount { private set; get; } = 0;
        public int SoliderLiveCount { private set; get; } = 0;

        public void Reset()
        {
            EnemyLiveCount = SoliderLiveCount = 0;
        }
        
        public override void VisitEnemy(Enemy.Enemy enemy)
        {
            if (!enemy.isDead)
            {
                Debug.Log("敌人数量+1");
                EnemyLiveCount++;
            }
        }

        public override void VisitSolider(Solider.Solider solider)
        {
            if (!solider.isDead)
            {
                Debug.Log("士兵数量+1");
                SoliderLiveCount++;
            }
        }
    }
}