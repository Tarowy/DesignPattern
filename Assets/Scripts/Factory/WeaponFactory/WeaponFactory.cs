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
            
            var attr = FactoryManager.AttrFactory.GetWeaponBaseAttr(weaponType);
            var loadWeapon = FactoryManager.AssetFactory.LoadWeapon(attr.AssetName);

            weapon = weaponType switch
            {
                WeaponType.Gun => new Gun(attr, loadWeapon),
                WeaponType.Rifle => new Rifle(attr, loadWeapon),
                WeaponType.Rocket => new Rocket(attr, loadWeapon),
                _ => null
            };

            return weapon;
        }
    }
}