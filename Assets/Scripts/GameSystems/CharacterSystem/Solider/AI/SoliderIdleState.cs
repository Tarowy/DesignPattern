using System.Collections.Generic;

namespace GameSystems.CharacterSystem.Solider.AI
{
    public class SoliderIdleState : SoliderState
    {
        /// <summary>
        /// 发现敌人，转变为SeeEnemy状态
        /// </summary>
        /// <param name="characters"></param>
        public override void Reason(List<Character> characters)
        {
            if (characters is not null && characters.Count > 0)
            {
                fsmSystem.PerformTransition(SoliderTransition.SeeEnemy);
            }
        }

        public override void Act()
        {
            character.PlayAnimation("Stand");
        }
    }
}