using System.Collections.Generic;
using GameSystems.CharacterSystem.Enemy.AI;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy
{
    public abstract class Enemy: Character
    {
        protected EnemyFsmSystem enemyFsmSystem;

        public Enemy()
        {
            MakeFsm();
        }
        
        public override void UpdateFsmAI(List<Character> characters)
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

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            PlayEffect();

            if (characterAttr.currentHp <= 0)
            {
                Dead();
            }
        }

        public abstract void PlayEffect();
    }
}