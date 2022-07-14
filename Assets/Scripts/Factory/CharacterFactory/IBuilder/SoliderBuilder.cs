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
            var attr = FactoryManager.AttrFactory.GetCharacterBaseAttr(type);

            character.CharacterAttr =
                new SoliderAttr(new SoliderAttrStrategy(), level, attr);
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