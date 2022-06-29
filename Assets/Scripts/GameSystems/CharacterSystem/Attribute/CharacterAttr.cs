using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class CharacterAttr
    {
        protected string name;
        protected int maxHp;
        protected int currentHp;
        protected float moveSpeed;
        protected string iconPath;

        protected int level;
        protected float criticalRate;

        protected IAttrStrategy attrStrategy;
    }
}