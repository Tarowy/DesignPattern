using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class SoliderAttr : CharacterAttr
    {
        public SoliderAttr(IAttrStrategy strategy, int level, string name, int maxHp, float moveSpeed, string iconPath,
            string prefabName) : base(
            strategy, level, name, maxHp, moveSpeed, iconPath, prefabName)
        {
        }
    }
}