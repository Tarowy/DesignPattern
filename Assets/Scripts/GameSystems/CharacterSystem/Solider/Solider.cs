using System.Collections.Generic;
using GameSystems.CharacterSystem.Solider.AI;

namespace GameSystems.CharacterSystem.Solider
{
    public abstract class Solider: Character
    {
        protected SoliderFsmSystem fsmSystem;

        protected Solider() : base()
        {
            MakeFsm();
        }

        /// <summary>
        /// 更新AI状态
        /// </summary>
        /// <param name="characters"></param>
        public override void UpdateFsmAI(List<Character> characters)
        {
            fsmSystem.CurrentState.Reason(characters);
            fsmSystem.CurrentState.Act(characters);
        }
        
        /// <summary>
        /// 构建状态机
        /// </summary>
        public void MakeFsm()
        {
            fsmSystem = new SoliderFsmSystem();

            var soliderIdleState = new SoliderIdleState(fsmSystem, this);
            /*
             * 静止只能转换为追赶状态
             *  1.当看到敌人的时候就转换为Chase状态
             */
            soliderIdleState.AddTransition(SoliderTransition.SeeEnemy, SoliderStateID.Chase);

            var soliderChaseState = new SoliderChaseState(fsmSystem, this);
            /*
             * 追赶状态可以切换成静止状态或攻击状态
             *  1.当没有敌人时就转换为Idle状态
             *  2.当靠近敌人时，就转换为Attack状态
             */
            soliderChaseState.AddTransition(SoliderTransition.NoEnemy, SoliderStateID.Idle);
            soliderChaseState.AddTransition(SoliderTransition.ToAttack,SoliderStateID.Attack);

            var soliderAttackState = new SoliderAttackState(fsmSystem,this);
            /*
             * 攻击状态可以切换成追赶状态或静止状态
             *  1.当没有敌人时就转换为Idle状态
             *  2.当敌人离得远时，就转换为Chase状态
             */
            soliderAttackState.AddTransition(SoliderTransition.NoEnemy,SoliderStateID.Idle);
            soliderAttackState.AddTransition(SoliderTransition.SeeEnemy, SoliderStateID.Chase);

            fsmSystem.AddState(soliderIdleState, soliderChaseState, soliderAttackState);
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            PlayEffect();

            if (characterAttr.currentHp <= 0)
            {
                PlayEffect();
                PlaySound();
                Dead();
            }
        }

        public abstract void PlayEffect();
        public abstract void PlaySound();
    }
}