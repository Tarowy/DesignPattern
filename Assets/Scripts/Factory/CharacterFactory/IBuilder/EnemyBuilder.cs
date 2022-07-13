using System;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Enemy;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory.IBuilder
{
    public class EnemyBuilder : CharacterBuilder
    {
        public EnemyBuilder(Character character, Type type, WeaponType weaponType,
            Vector3 spawnPosition, int level) :
            base(character, type, weaponType, spawnPosition, level)
        {
        }

        public override void AddCharacterAttr()
        {
            //设置属性
            var name = "无";
            var maxHp = 0;
            var moveSpeed = 0f;
            var iconPath = "none";
            var prefabName = "none";

            if (type == typeof(Elf))
            {
                name = "精灵";
                maxHp = 100;
                moveSpeed = 3f;
                iconPath = "ElfIcon";
                prefabName = "Enemy1";
            }
            else if (type == typeof(Ogre))
            {
                name = "食人魔";
                maxHp = 120;
                moveSpeed = 4f;
                iconPath = "OgreIcon";
                prefabName = "Enemy2";
            }
            else if (type == typeof(Troll))
            {
                name = "巨魔";
                maxHp = 200;
                moveSpeed = 1f;
                iconPath = "TrollIcon";
                prefabName = "Enemy3";
            }
            else
            {
                Debug.LogError($"{type}不是Enemy类型");
            }

            character.CharacterAttr = new EnemyAttr(new EnemyAttrStrategy(), level,
                name, maxHp, moveSpeed, iconPath, prefabName);
        }

        public override void AddGameObject()
        {
            var loadEnemy = FactoryManager.AssetFactory.LoadEnemy(character.CharacterAttr.PrefabName);
            loadEnemy.transform.position = spawnPosition;
            character.CharacterObject = loadEnemy;
        }

        public override void AddWeapon()
        {
            character.Weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        }
    }
}