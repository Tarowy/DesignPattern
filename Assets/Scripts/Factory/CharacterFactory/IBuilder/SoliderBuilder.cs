using System;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory.IBuilder
{
    public class SoliderBuilder : CharacterBuilder
    {
        public SoliderBuilder(Character character, Type type, WeaponType weaponType,
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

            if (type == typeof(Captain))
            {
                name = "上尉";
                maxHp = 100;
                moveSpeed = 3f;
                iconPath = "CaptainIcon";
                prefabName = "Soilder3";
            }
            else if (type == typeof(Sergeant))
            {
                name = "中士";
                maxHp = 90;
                moveSpeed = 3f;
                iconPath = "SergeantIcon";
                prefabName = "Soilder2";
            }
            else if (type == typeof(Rookie))
            {
                name = "下士";
                maxHp = 90;
                moveSpeed = 2.5f;
                iconPath = "RookieIcon";
                prefabName = "Soilder1";
            }
            else
            {
                Debug.LogError($"{type}不是Solider类型");
            }

            character.CharacterAttr =
                new SoliderAttr(new SoliderAttrStrategy(), level, 
                    name, maxHp, moveSpeed, iconPath, prefabName);
        }

        public override void AddGameObject()
        {
            var loadSolider = FactoryManager.AssetFactory.LoadSolider(character.CharacterAttr.PrefabName);
            loadSolider.transform.position = spawnPosition;
            character.CharacterObject = loadSolider;
        }

        public override void AddWeapon()
        {
            character.Weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        }
    }
}