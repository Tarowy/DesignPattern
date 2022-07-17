using System;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using Pattern.FacadeAndSingletonPattern;
using Tools;
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
            var attr = FactoryManager.AttrFactory.GetCharacterBaseAttr(type);

            character.CharacterAttr =
                new SoliderAttr(new SoliderAttrStrategy(), level, attr);
        }

        public override void AddGameObject()
        {
            var loadSolider =
                InstantiateTool.InstantiateObj(
                    FactoryManager.AssetFactory.LoadSolider(character.CharacterAttr.PrefabName));
            loadSolider.transform.position = spawnPosition;
            character.CharacterObject = loadSolider;
        }

        public override void AddWeapon()
        {
            character.Weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        }

        public override void AddToCharacterSystem()
        {
            GameFacade.Instance.AddSolider(character as Solider);
        }
    }
}