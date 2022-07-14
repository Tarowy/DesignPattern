using Factory.AssetFactory;
using Factory.AttrFactory;
using Factory.CharacterFactory;
using Factory.WeaponFactory;

namespace Factory
{
    public static class FactoryManager
    {
        private static IAssetFactory _assetFactory;
        private static ICharacterFactory _soliderFactory;
        private static ICharacterFactory _enemyFactory;
        private static IWeaponFactory _weaponFactory;
        private static IAttrFactory _attrFactory;

        public static IAssetFactory AssetFactory => _assetFactory ??= new ResourceAssetFactory();
        public static ICharacterFactory EnemyFactory => _soliderFactory ??= new EnemyFactory();
        public static ICharacterFactory SoliderFactory => _enemyFactory ??= new SoliderFactory();
        public static IWeaponFactory WeaponFactory => _weaponFactory ??= new WeaponFactory.WeaponFactory();
        public static IAttrFactory AttrFactory => _attrFactory ??= new AttrFactory.AttrFactory();
    }
}