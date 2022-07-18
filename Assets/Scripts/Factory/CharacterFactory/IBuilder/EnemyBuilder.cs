using System;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Enemy;
using Pattern.FacadeAndSingletonPattern;
using Tools;
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
            var attr = FactoryManager.AttrFactory.GetCharacterBaseAttr(type);

            character.CharacterAttr = new EnemyAttr(new EnemyAttrStrategy(), level, attr);
        }

        public override void AddGameObject()
        {
            var loadEnemy =
                InstantiateTool.InstantiateObj(
                    FactoryManager.AssetFactory.LoadEnemy(character.CharacterAttr.PrefabName));
            loadEnemy.transform.position = spawnPosition;
            character.CharacterObject = loadEnemy;
        }

        public override void AddWeapon()
        {
            character.Weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        }

        public override void AddToCharacterSystem()
        {
            GameFacade.Instance.AddEnemy(character as Enemy);
        }
    }
}