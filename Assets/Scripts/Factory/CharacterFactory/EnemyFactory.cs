using Factory.CharacterFactory.IBuilder;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;
using GameSystems.CharacterSystem.Enemy;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory
{
    public class EnemyFactory: ICharacterFactory
    {
        public Character CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : Character, new()
        {
            Character character = new T();

            var enemyBuilder = new EnemyBuilder(character,typeof(T),weaponType,spawnPosition,lv);
            return CharacterDirector.Construct(enemyBuilder);
        }
    }
}