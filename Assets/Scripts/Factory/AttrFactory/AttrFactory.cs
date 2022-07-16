using System;
using System.Collections.Generic;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;
using Weapon.Attr;

namespace Factory.AttrFactory
{
    public class AttrFactory : IAttrFactory
    {
        /*
         * 享元模式（Flyweight Pattern）主要用于减少创建对象的数量，以减少内存占用和提高性能。
         * 这种类型的设计模式属于结构型模式，它提供了减少对象数量从而改善应用所需的对象结构的方式。
         * 享元模式尝试重用现有的同类对象，如果未找到匹配的对象，则创建新对象。
         * https://www.runoob.com/design-pattern/flyweight-pattern.html
         */
        private Dictionary<Type, CharacterBaseAttr> _characterAttrs;
        private Dictionary<WeaponType, WeaponBaseAttr> _weaponAttrs;


        public AttrFactory()
        {
            InitAttrDictionary();
        }

        private void InitAttrDictionary()
        {
            _characterAttrs = new Dictionary<Type, CharacterBaseAttr>
            {
                {
                    typeof(Rookie), new CharacterBaseAttr("下士", 80,
                        2.5f, "RookieIcon", "Soldier1", 0)
                },
                {
                    typeof(Sergeant), new CharacterBaseAttr("中士", 90,
                        3f, "SergeantIcon", "Soldier2", 0)
                },
                {
                    typeof(Captain), new CharacterBaseAttr("上尉", 100,
                        3f, "CaptainIcon", "Soldier3", 0)
                },
                {
                    typeof(Elf), new CharacterBaseAttr("精灵", 100,
                        3f, "ElfIcon", "Enemy1", 0.2f)
                },
                {
                    typeof(Ogre), new CharacterBaseAttr("食人魔", 120,
                        4f, "OgreIcon", "Enemy2", 0.3f)
                },
                {
                    typeof(Troll), new CharacterBaseAttr("巨魔", 200,
                        1f, "TrollIcon", "Enemy3", 0.4f)
                }
            };

            _weaponAttrs = new Dictionary<WeaponType, WeaponBaseAttr>()
            {
                {
                    WeaponType.Gun, new WeaponBaseAttr("Gun", 5,
                        20, "WeaponGun")
                },
                {
                    WeaponType.Rifle, new WeaponBaseAttr("Rifle", 7,
                        30, "WeaponRifle")
                },
                {
                    WeaponType.Rocket,new WeaponBaseAttr("WeaponRocket",8,
                        40,"WeaponRocket")
                }
            };
        }

        public CharacterBaseAttr GetCharacterBaseAttr(Type type)
        {
            if (!_characterAttrs.ContainsKey(type))
            {
                Debug.LogError($"字典中没有{type}类型");
            }

            return _characterAttrs[type];
        }

        public WeaponBaseAttr GetWeaponBaseAttr(WeaponType type)
        {
            if (!_weaponAttrs.ContainsKey(type))
            {
                Debug.LogError($"字典中没有{type}类型");
            }

            return _weaponAttrs[type];
        }
    }
}