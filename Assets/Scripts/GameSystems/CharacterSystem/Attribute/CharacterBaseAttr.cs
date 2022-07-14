namespace GameSystems.CharacterSystem.Attribute
{
    public class CharacterBaseAttr
    {
        //这些属性对同一种类型的角色来说是一样的且不需要更改，所以可以单独提取出来让所有同一类型的角色共用一份
        protected string name;
        protected int maxHp;
        protected float moveSpeed;
        protected string iconPath;
        protected string prefabName;
        protected float criticalRate;
        
        public CharacterBaseAttr
            (string name,int maxHp,float moveSpeed,string iconPath,string prefabName,float criticalRate)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.iconPath = iconPath;
            this.prefabName = prefabName;
            this.criticalRate = criticalRate;
        }
        
        public string Name => name;
        public int MaxHp => maxHp;
        public float MoveSpeed => moveSpeed;
        public string IconPath => iconPath;
        public string PrefabName => prefabName;
        public float CriticalRate => criticalRate;
    }
}