using System;
using GameSystems.CharacterSystem;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory.IBuilder
{
    public abstract class CharacterBuilder
    {
        protected Character character;
        protected Type type;
        protected WeaponType weaponType;
        protected Vector3 spawnPosition;
        protected int level;

        protected CharacterBuilder(Character character, Type type, WeaponType weaponType, Vector3 spawnPosition, int level)
        {
            this.character = character;
            this.type = type;
            this.weaponType = weaponType;
            this.spawnPosition = spawnPosition;
            this.level = level;
        }

        public abstract void AddCharacterAttr();
        public abstract void AddGameObject();
        public abstract void AddWeapon();

        public virtual Character GetResult()
        {
            return character;
        }
    }
}