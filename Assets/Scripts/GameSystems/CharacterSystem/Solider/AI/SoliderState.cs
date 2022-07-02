using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Solider.AI
{
    /// <summary>
    /// 转换状态的条件
    /// </summary>
    public enum SoliderTransition
    {
        NullTransition = 0,
        SeeEnemy,
        NoEnemy,
        ToAttack
    }

    /// <summary>
    /// 不同状态的ID
    /// </summary>
    public enum SoliderStateID
    {
        NullState,
        Idle,
        Chase,
        Attack
    }

    /// <summary>
    /// 士兵的状态类
    /// </summary>
    public abstract class SoliderState
    {
        //由子类调用FSM的Transition来转换其中储存的状态
        protected Dictionary<SoliderTransition, SoliderStateID> states = new();
        protected SoliderStateID stateID;
        public Character character; //该状态属于哪个角色
        public SoliderFsmSystem fsmSystem;

        public SoliderState(SoliderFsmSystem system,Character character)
        {
            fsmSystem = system;
            this.character = character;
        }

        public SoliderStateID SoliderStateID => stateID;

        public void AddTransition(SoliderTransition transition, SoliderStateID id)
        {
            if (transition==SoliderTransition.NullTransition)
            {
                Debug.LogError("SoliderTransition不能为空");
            }

            if (id==SoliderStateID.NullState)
            {
                Debug.LogError("SoliderStateID不能为空");
            }

            if (states.ContainsKey(transition))
            {
                Debug.LogError($"{transition}已添加过");
            }

            states.Add(transition, id);
        }

        public void DeleteTransition(SoliderTransition transition)
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
        public SoliderStateID GetOutputState(SoliderTransition transition)
        {
            if (states.ContainsKey(transition))
            {
                return states[transition];
            }
            return SoliderStateID.NullState;
        }

        public virtual void DoBeforeEntering() {}
        public virtual void DoBeforeLeaving() {}

        public abstract void Reason(List<Character> characters);
        public abstract void Act(List<Character> characters);
    }
}