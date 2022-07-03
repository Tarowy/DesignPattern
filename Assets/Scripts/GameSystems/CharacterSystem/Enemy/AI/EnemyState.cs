using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy.AI
{
    /// <summary>
    /// 转换状态的条件
    /// </summary>
    public enum EnemyTransition
    {
        NullTransition = 0,
        LostSolider,
        ToAttack
    }

    /// <summary>
    /// 不同状态的ID
    /// </summary>
    public enum EnemyStateID
    {
        NullState,
        Chase,
        Attack
    }
    
    public abstract class EnemyState
    {
        //由子类调用FSM的Transition来转换其中储存的状态
        protected Dictionary<EnemyTransition, EnemyStateID> states = new();
        protected EnemyStateID stateID;
        public Character character; //该状态属于哪个角色
        public EnemyFsmSystem fsmSystem;

        public EnemyState(EnemyFsmSystem system,Character character)
        {
            fsmSystem = system;
            this.character = character;
        }

        public EnemyStateID EnemyStateID => stateID;

        public void AddTransition(EnemyTransition transition, EnemyStateID id)
        {
            if (transition==EnemyTransition.NullTransition)
            {
                Debug.LogError("EnemyTransition不能为空");
            }

            if (id==EnemyStateID.NullState)
            {
                Debug.LogError("EnemyStateID不能为空");
            }

            if (states.ContainsKey(transition))
            {
                Debug.LogError($"{transition}已添加过");
            }

            states.Add(transition, id);
        }

        public void DeleteTransition(EnemyTransition transition)
        {
            if (!states.ContainsKey(transition))
            {
                Debug.LogError($"转换条件{transition}不存在");
            }
            
            states.Remove(transition);
        }

        /// <summary>
        /// 根据输入的转换条件得到转换后的状态
        /// </summary>
        /// <param name="transition"></param>
        /// <returns></returns>
        public EnemyStateID GetOutputState(EnemyTransition transition)
        {
            if (states.ContainsKey(transition))
            {
                return states[transition];
            }
            return EnemyStateID.NullState;
        }

        public virtual void DoBeforeEntering() {}
        public virtual void DoBeforeLeaving() {}

        public abstract void Reason(List<Character> characters);
        public abstract void Act(List<Character> characters);
    }
}