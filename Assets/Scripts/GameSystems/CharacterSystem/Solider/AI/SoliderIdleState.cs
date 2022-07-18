using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Solider.AI
{
    public class SoliderIdleState : SoliderState
    {
        public SoliderIdleState(SoliderFsmSystem system,Character character) : base(system,character)
        {
            stateID = SoliderStateID.Idle;
        }
        
        public override void Reason(List<Character> characters)
        {
            //发现敌人，转变为SeeEnemy状态
            if (characters is not null && characters.Count > 0)
            {
                character.NavMeshAgent.isStopped = false;
                Debug.Log("Idle 转为 chase");
                fsmSystem.PerformTransition(SoliderTransition.SeeEnemy);
            }
        }

        public override void Act(List<Character> characters)
        {
            character.NavMeshAgent.isStopped = true;
            character.PlayAnimation("stand");
        }
    }
}