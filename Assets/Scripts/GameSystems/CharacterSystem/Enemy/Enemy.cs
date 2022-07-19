using System.Collections.Generic;
using GameSystems.CharacterSystem.Enemy.AI;
using GameSystems.CharacterSystem.Visitor;
using GameSystems.GameEventSystem;
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
            //防止敌人死亡后由于GameObject未被销毁而多次调用Dead导致敌人死亡后多次计数
            if (isDead)
            {
                return;
            }
            base.GetDamage(damage);
            PlayEffect();

            if (characterAttr.currentHp <= 0)
            {
                Dead();
            }
        }

        public override void Dead()
        {
            base.Dead();
            GameFacade.Instance.NotifySubject(GameEventType.EnemyDead);
        }

        protected override void RemoveSelf()
        {
            GameFacade.Instance.RemoveEnemy(this);
            base.RemoveSelf();
        }

        public override void RunVisitor(CharacterVisitor characterVisitor)
        {
            characterVisitor.VisitEnemy(this);
        }
        
        public abstract void PlayEffect();
    }
}