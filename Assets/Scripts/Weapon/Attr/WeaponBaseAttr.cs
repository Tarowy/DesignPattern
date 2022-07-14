namespace Weapon.Attr
{
    public class WeaponBaseAttr
    {
        protected string name;
        protected int damage;
        protected float range;
        protected string assetName;

        public WeaponBaseAttr(string name, int damage, float range, string assetName)
        {
            this.name = name;
            this.damage = damage;
            this.range = range;
            this.assetName = assetName;
        }

        public string Name => name;
        public int Damage => damage;
        public float Range => range;
        public string AssetName => assetName;
    }
}