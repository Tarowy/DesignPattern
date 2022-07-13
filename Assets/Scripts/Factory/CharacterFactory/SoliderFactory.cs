using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory
{
    public class SoliderFactory : ICharacterFactory
    {
        public Character CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)
            where T : Character, new()
        {
            Character character = new T();
            
            //设置属性
            var name = "无";
            var maxHp = 0;
            var moveSpeed = 0f;
            var iconPath = "none";
            var prefabName = "none";

            var type = typeof(T);

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
                return null;
            }

            character.CharacterAttr =
                new SoliderAttr(new SoliderAttrStrategy(),lv, name, maxHp, moveSpeed, iconPath, prefabName);
            
            var loadSolider = FactoryManager.AssetFactory.LoadSolider(prefabName);
            loadSolider.transform.position = spawnPosition;
            character.CharacterObject = loadSolider;
            
            character.Weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);

            return character;
        }
    }
}