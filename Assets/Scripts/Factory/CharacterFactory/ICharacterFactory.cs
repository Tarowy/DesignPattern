using GameSystems.CharacterSystem;
using UnityEngine;
using Weapon;

namespace Factory.CharacterFactory
{
    /// <summary>
    /// 工厂模式（Factory Pattern）是最常用的设计模式之一。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// 在工厂模式中，我们在创建对象时不会对客户端暴露创建逻辑，并且是通过使用一个共同的接口来指向新创建的对象。
    /// 抽象工厂模式（Abstract Factory Pattern）是围绕一个超级工厂创建其他工厂。
    /// https://www.runoob.com/design-pattern/factory-pattern.html
    /// 
    /// 该超级工厂又称为其他工厂的工厂。
    /// 这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// 在抽象工厂模式中，接口是负责创建一个相关对象的工厂，不需要显式指定它们的类。每
    /// 个生成的工厂都能按照工厂模式提供对象。
    /// https://www.runoob.com/design-pattern/abstract-factory-pattern.html
    /// </summary>
    public interface ICharacterFactory
    {
        GameSystems.CharacterSystem.Character CreateCharacter<T>
        (WeaponType weaponType, Vector3 spawnPosition, int lv = 1) 
            where T : Character, new();
    }
}