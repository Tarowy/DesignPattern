using System.Collections.Generic;
using GameSystems.CharacterSystem.Enemy.AI;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy
{
    public enum EnemyType
    {
        Elf,
        Ogre,
        Troll
    }
    public abstract class Enemy: Character
    {
        protected EnemyFsmSystem enemyFsmSystem;

        public Enemy()
        {
            // 
        }
        
        public override void UpdateFsmAI(List<Character> characters)
        {
            if (isDead)
            {
                return;
            }
            enemyFsmSystem.CurrentState.Reason(characters);
            enemyFsmSystem.CurrentState.Act(characters);
        }

        protected override void MakeFsm()
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
        
        protected override void RemoveSelf()
        {
            GameFacade.Instance.RemoveEnemy(this);
            base.RemoveSelf();
        }
        
        public abstract void PlayEffect();
    }
}