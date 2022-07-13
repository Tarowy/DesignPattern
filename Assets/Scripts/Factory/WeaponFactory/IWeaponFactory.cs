using UnityEngine;
using Weapon;

namespace Factory.WeaponFactory
{
    public interface IWeaponFactory
    {
        Weapon.Weapon CreateWeapon(WeaponType weaponType);
    }
}