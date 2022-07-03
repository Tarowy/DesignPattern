using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy.AI
{
    public class EnemyFsmSystem
    {
        protected List<EnemyState> stateList = new();

        protected EnemyState currentState;
        public EnemyState CurrentState => currentState;

        /// <summary>
        /// 可变长参数，将所有状态都添加到状态机中
        /// </summary>
        /// <param name="states"></param>
        public void AddState(params EnemyState[] states)
        {
            foreach (var s in states)
            {
                AddState(s);
            }
        }
        
        /// <summary>
        /// 添加一个状态
        /// </summary>
        /// <param name="state"></param>
        public void AddState(EnemyState state)
        {
            if (state == null)
            {
                Debug.LogError("EnemyState为空");
                return;
            }

            if (stateList.Count == 0)
            {
                stateList.Add(state);
                currentState = state;
                currentState.DoBeforeEntering();
                return;
            }

            if (stateList.Any(s => s.EnemyStateID == state.EnemyStateID))
            {
                Debug.LogError($"{state}已存在");
                return;
            }

            stateList.Add(state);
        }

        public void DeleteState(EnemyStateID stateID)
        {
            if (stateID == EnemyStateID.NullState)
            {
                Debug.LogError($"{stateID}为空状态");
                return;
            }

            foreach (var s in stateList.Where(s => s.EnemyStateID == stateID))
            {
                stateList.Remove(s);
                return;
            }

            Debug.LogError($"{stateID}不存在");
        }

        public void PerformTransition(EnemyTransition transition)
        {
            if (transition == EnemyTransition.NullTransition)
            {
                Debug.LogError("转换条件为空");
            }

            var nextState = currentState.GetOutputState(transition);
            if (nextState==EnemyStateID.NullState)
            {
                Debug.LogError($"要转换的{nextState}状态为空");
            }

            foreach (var s in stateList.Where(s=>s.EnemyStateID==nextState))
            {
                currentState.DoBeforeLeaving();
                currentState = s;
                currentState.DoBeforeEntering();
            }
        }
    }
}