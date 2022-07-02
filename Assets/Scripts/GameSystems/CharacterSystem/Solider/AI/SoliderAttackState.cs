using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Solider.AI
{
    public class SoliderAttackState : SoliderState
    {
        private float _currentAttackCounter;
        private float _attackCoolDown;

        public SoliderAttackState(SoliderFsmSystem system, Character character) : base(system, character)
        {
            stateID = SoliderStateID.Attack;
            _attackCoolDown = 1f;
        }

        public override void Reason(List<Character> characters)
        {
            if (characters is null || characters.Count == 0)
            {
                fsmSystem.PerformTransition(SoliderTransition.NoEnemy);
                return;
            }

            var distance = Vector3.Distance(character.Position, characters[0].Position);
            if (distance > character.WeaponRange)
            {
                fsmSystem.PerformTransition(SoliderTransition.SeeEnemy);
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
                character.Attack(characters[0]);
                _currentAttackCounter = _attackCoolDown;
            }
        }
    }
}