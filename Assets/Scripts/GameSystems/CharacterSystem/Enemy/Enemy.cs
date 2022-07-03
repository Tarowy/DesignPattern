using System.Collections.Generic;
using GameSystems.CharacterSystem.Enemy.AI;

namespace GameSystems.CharacterSystem.Enemy
{
    public class Enemy: Character
    {
        protected EnemyFsmSystem enemyFsmSystem;

        public Enemy()
        {
            MakeFsm();
        }
        
        public void UpdateFsmAI(List<Character> characters)
        {
            enemyFsmSystem.CurrentState.Reason(characters);
            enemyFsmSystem.CurrentState.Act(characters);
        }

        public void MakeFsm()
        {
            enemyFsmSystem = new EnemyFsmSystem();

            var enemyChaseState = new EnemyChaseState(enemyFsmSystem,this);
            enemyChaseState.AddTransition(EnemyTransition.ToAttack, EnemyStateID.Attack);

            var enemyAttackState = new EnemyAttackState(enemyFsmSystem,this);
            enemyAttackState.AddTransition(EnemyTransition.LostSolider, EnemyStateID.Chase);

            enemyFsmSystem.AddState(enemyChaseState, enemyAttackState);
        }
    }
}