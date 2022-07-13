using Factory.AssetFactory;
using Factory.CharacterFactory;
using Factory.WeaponFactory;

namespace Factory
{
    public class FactoryManager
    {
        private static IAssetFactory _assetFactory;
        private static ICharacterFactory _soliderFactory;
        private static ICharacterFactory _enemyFactory;
        private static IWeaponFactory _weaponFactory;

        public static IAssetFactory AssetFactory => _assetFactory ??= new ResourceAssetFactory();
        public static ICharacterFactory EnemyFactory => _soliderFactory ??= new EnemyFactory();
        public static ICharacterFactory SoliderFactory => _enemyFactory ??= new SoliderFactory();
        public static IWeaponFactory WeaponFactory => _weaponFactory ??= new WeaponFactory.WeaponFactory();
    }
}