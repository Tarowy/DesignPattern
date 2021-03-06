using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystems.CharacterSystem.Solider.AI
{
    /// <summary>
    /// 有限状态机的核心，需要靠它来转换不同的状态
    /// </summary>
    public class SoliderFsmSystem
    {
        protected List<SoliderState> stateList = new();

        protected SoliderState currentState;
        public SoliderState CurrentState => currentState;

        /// <summary>
        /// 可变长参数，将所有状态都添加到状态机中
        /// </summary>
        /// <param name="states"></param>
        public void AddState(params SoliderState[] states)
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
        public void AddState(SoliderState state)
        {
            if (state == null)
            {
                Debug.LogError("SoliderState为空");
                return;
            }

            if (stateList.Count == 0)
            {
                stateList.Add(state);
                currentState = state;
                currentState.DoBeforeEntering();
                return;
            }

            if (stateList.Any(s => s.SoliderStateID == state.SoliderStateID))
            {
                Debug.LogError($"{state}已存在");
                return;
            }

            stateList.Add(state);
        }

        public void DeleteState(SoliderStateID stateID)
        {
            if (stateID == SoliderStateID.NullState)
            {
                Debug.LogError($"{stateID}为空状态");
                return;
            }

            foreach (var s in stateList.Where(s => s.SoliderStateID == stateID))
            {
                stateList.Remove(s);
                return;
            }

            Debug.LogError($"{stateID}不存在");
        }

        public void PerformTransition(SoliderTransition transition)
        {
            if (transition == SoliderTransition.NullTransition)
            {
                Debug.LogError("转换条件为空");
            }

            var nextState = currentState.GetOutputState(transition);
            if (nextState==SoliderStateID.NullState)
            {
                Debug.LogError($"要转换的{nextState}状态为空");
            }

            foreach (var s in stateList.Where(s=>s.SoliderStateID==nextState))
            {
                currentState.DoBeforeLeaving();
                currentState = s;
                currentState.DoBeforeEntering();
            }
        }
    }
}