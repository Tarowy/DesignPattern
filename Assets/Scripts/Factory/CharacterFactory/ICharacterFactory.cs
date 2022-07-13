using GameSystems.CharacterSystem;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory
{
    /// <summary>
    /// 工厂模式（Factory Pattern）是最常用的设计模式之一。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// 在工厂模式中，我们在创建对象时不会对客户端暴露创建逻辑，并且是通过使用一个共同的接口来指向新创建的对象。
    /// </summary>
    public interface ICharacterFactory
    {
        GameSystems.CharacterSystem.Character CreateCharacter<T>
        (WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
            where T : Character, new();
    }
}