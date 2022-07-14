using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class SoliderAttr : CharacterAttr
    {
        public SoliderAttr(IAttrStrategy strategy, int level, CharacterBaseAttr characterBaseAttr) : base(
            strategy, level, characterBaseAttr)
        {
        }
    }
}