using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy.AI
{
    public class EnemyAttackState: EnemyState
    {
        private float _currentAttackCounter;
        private float _attackCoolDown;
        
        public EnemyAttackState(EnemyFsmSystem system, Character character) : base(system, character)
        {
            stateID = EnemyStateID.Attack;
            _attackCoolDown = 1f;
        }

        public override void Reason(List<Character> characters)
        {
            if (characters is null || characters.Count == 0)
            {
                character.NavMeshAgent.isStopped = false;
                fsmSystem.PerformTransition(EnemyTransition.LostSolider);
                return;
            }

            var distance = Vector3.Distance(characters[0].Position,character.Position);
            if (distance > character.WeaponRange)
            {
                character.NavMeshAgent.isStopped = false;
                fsmSystem.PerformTransition(EnemyTransition.LostSolider);
            }
        }

        public override void Act(List<Character> characters)
        {
            if (characters is null || characters.Count == 0)
            {
                return;
            }

            _currentAttackCounter -= Time.deltaTime;
            if (_currentAttackCounter <= 0)
            {
                //攻击时需要停止移动，防止出现滑动挤压的情况
                character.NavMeshAgent.isStopped = true;
                character.Attack(characters[0]);
                _currentAttackCounter = _attackCoolDown;
            }
        }
    }
}