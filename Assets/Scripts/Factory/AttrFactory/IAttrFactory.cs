using System;
using GameSystems.CharacterSystem.Attribute;
using Weapon;
using Weapon.Attr;

namespace Factory.AttrFactory
{
    public interface IAttrFactory
    {
        CharacterBaseAttr GetCharacterBaseAttr(Type type);
        WeaponBaseAttr GetWeaponBaseAttr(WeaponType type);
    }
}