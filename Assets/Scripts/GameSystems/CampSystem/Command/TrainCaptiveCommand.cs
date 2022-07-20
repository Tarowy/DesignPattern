using Factory;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;
using Weapon;

namespace GameSystems.CampSystem.Command
{
    public class TrainCaptiveCommand : TrainCampCommand
    {
        private EnemyType _enemyType;
        private WeaponType _weaponType;
        private Vector3 _position;
        private int _level;

        public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 position, int level = 1)
        {
            _enemyType = enemyType;
            _weaponType = weaponType;
            _position = position;
            _level = level;
        }

        public override void Execute()
        {
            var enemy = _enemyType switch
            {
                EnemyType.Elf => FactoryManager.EnemyFactory.CreateCharacter<Elf>(_weaponType, _position) as Enemy,
                EnemyType.Ogre => FactoryManager.EnemyFactory.CreateCharacter<Ogre>(_weaponType, _position) as Enemy,
                EnemyType.Troll => FactoryManager.EnemyFactory.CreateCharacter<Troll>(_weaponType, _position) as Enemy,
                _ => null
            };

            //使用适配器将敌人转换成士兵
            GameFacade.Instance.RemoveEnemy(enemy);
            var captive = new Captive(enemy);
            GameFacade.Instance.AddSolider(captive);
        }
    }
}