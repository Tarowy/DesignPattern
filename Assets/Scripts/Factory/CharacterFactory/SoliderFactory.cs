using Factory.CharacterFactory.IBuilder;
using GameSystems.CharacterSystem;
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

            var soliderBuilder = new SoliderBuilder
                (character,typeof(T),weaponType,spawnPosition,lv);
            return CharacterDirector.Construct(soliderBuilder);
        }
    }
}