using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.CharacterSystem.Solider.AI
{
    public class SoliderChaseState : SoliderState
    {
        public SoliderChaseState(SoliderFsmSystem system, Character character) : base(system, character)
        {
            stateID = SoliderStateID.Chase;
        }

        public override void Reason(List<Character> characters)
        {
            if (characters is null || characters.Count == 0)
            {
                fsmSystem.PerformTransition(SoliderTransition.NoEnemy);
                return;
            }

            var distance = Vector3.Distance(characters[0].Position, character.Position);
            if (distance <= character.WeaponRange)
            {
                Debug.Log("chase 转换为 attack");
                fsmSystem.PerformTransition(SoliderTransition.ToAttack);
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