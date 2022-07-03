using System.Collections.Generic;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;

namespace GameSystems.CharacterSystem.Enemy.AI
{
    public class EnemyChaseState: EnemyState
    {
        public EnemyChaseState(EnemyFsmSystem system, Character character) : base(system, character)
        {
            stateID = EnemyStateID.Chase;
        }

        private Vector3 _targetPosition;
        public override void DoBeforeEntering()
        {
            character.SetPosition(GameFacade.Instance.GetEnemyTargetPosition());
        }

        public override void Reason(List<Character> characters)
        {
            if (characters is null || characters.Count <= 0) return;
            
            var distance = Vector3.Distance(characters[0].Position,character.Position);
            if (distance <= character.WeaponRange)
            {
                fsmSystem.PerformTransition(EnemyTransition.ToAttack);
            }
        }

        public override void Act(List<Character> characters)
        {
            if (characters is not null && characters.Count > 0)
            {
                character.SetPosition(characters[0].Position);
            }
        }
    }
}