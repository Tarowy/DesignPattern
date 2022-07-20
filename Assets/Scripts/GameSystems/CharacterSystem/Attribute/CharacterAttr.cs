using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class CharacterAttr
    {
        protected CharacterBaseAttr characterBaseAttr;
        
        public int currentHp;
        protected int level;

        protected IAttrStrategy attrStrategy;

        //伤害减免值，与等级相关
        public int damageDescValue;
        
        public CharacterAttr
            (IAttrStrategy strategy,int level,CharacterBaseAttr characterBaseAttr)
        {
            attrStrategy = strategy;
            this.characterBaseAttr = characterBaseAttr;
            this.level = level;
            
            //一个角色的伤害减免从一出生就固定，所以只需要一开始赋值
            damageDescValue = attrStrategy.GetDamageReduceValue(level);
            currentHp = this.characterBaseAttr.MaxHp + attrStrategy.GetExtraHp(level);
        }

        public int CriticalValue => attrStrategy.GetCriticalDamage(characterBaseAttr.CriticalRate);

        public string PrefabName => characterBaseAttr.PrefabName;

        public IAttrStrategy AttrStrategy
        {
            set => attrStrategy = value;
            get => attrStrategy;
        }

        public CharacterBaseAttr CharacterBaseAttr => characterBaseAttr;


        public void GetDamage(int damage)
        {
            damage -= damageDescValue;
            //最低伤害为5
            damage = damage < 5 ? 5 : damage;
            currentHp -= damage;
        }
    }
}