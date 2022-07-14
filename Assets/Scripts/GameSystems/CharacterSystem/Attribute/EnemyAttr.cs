using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class EnemyAttr : CharacterAttr
    {
        public EnemyAttr(IAttrStrategy strategy, int level, CharacterBaseAttr characterBaseAttr) : base(
            strategy, level, characterBaseAttr)
        {
        }
    }
}