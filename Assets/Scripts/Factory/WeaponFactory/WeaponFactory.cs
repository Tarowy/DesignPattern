using Factory.AssetFactory;
using UnityEngine;
using Weapon;

namespace Factory.WeaponFactory
{
    public class WeaponFactory: IWeaponFactory
    {
        public Weapon.Weapon CreateWeapon(WeaponType weaponType)
        {
            Weapon.Weapon weapon = null;
            var assetName = "";

            assetName = weaponType switch
            {
                WeaponType.Gun => "WeaponGun",
                WeaponType.Rifle => "WeaponRifle",
                WeaponType.Rocket => "WeaponRocket",
                _ => assetName
            };

            var loadWeapon = FactoryManager.AssetFactory.LoadWeapon(assetName);

            weapon = weaponType switch
            {
                WeaponType.Gun => new Gun(20, 5, loadWeapon),
                WeaponType.Rifle => new Rifle(30, 7, loadWeapon),
                WeaponType.Rocket => new Rocket(40, 8, loadWeapon),
                _ => null
            };

            return weapon;
        }
    }
}