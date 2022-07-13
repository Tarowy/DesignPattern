using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Attribute
{
    public class CharacterAttr
    {
        protected string name;
        protected int maxHp;
        protected float moveSpeed;
        protected string iconPath;
        protected string prefabName;

        public int currentHp;
        protected int level;
        protected float criticalRate;

        protected IAttrStrategy attrStrategy;

        //伤害减免值，与等级相关
        public int damageDescValue;
        
        public CharacterAttr
            (IAttrStrategy strategy,int level,string name,int maxHp,float moveSpeed,string iconPath,string prefabName)
        {
            attrStrategy = strategy;
            this.name = name;
            this.maxHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.iconPath = iconPath;
            this.prefabName = prefabName;
            this.level = level;
            
            //一个角色的伤害减免从一出生就固定，所以只需要一开始赋值
            damageDescValue = attrStrategy.GetDamageReduceValue(level);
            currentHp = maxHp + attrStrategy.GetExtraHp(level);
        }

        public int CriticalValue => attrStrategy.GetCriticalDamage(criticalRate);


        public void GetDamage(int damage)
        {
            damage -= damageDescValue;
            //最低伤害为5
            damage = damage < 5 ? 5 : damage;
            currentHp -= damage;
        }
    }
}