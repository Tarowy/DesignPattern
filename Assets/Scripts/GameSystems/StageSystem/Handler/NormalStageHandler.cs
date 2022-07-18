using Factory;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;

namespace GameSystems.StageSystem.Handler
{
    public class NormalStageHandler : StageHandler
    {
        private EnemyType _enemyType;
        private WeaponType _weaponType;

        private int _count;
        private Vector3 _position;

        private float _currentGenerateTime;
        private float _generateInterval = 1;
        private float _generateCount;

        public NormalStageHandler(int level, int finishCount,
            EnemyType enemyType, WeaponType weaponType,
            int count, Vector3 position, StageSystem stageSystem)
            : base(level, finishCount, stageSystem)
        {
            _enemyType = enemyType;
            _weaponType = weaponType;
            _count = count;
            _position = position;
            _currentGenerateTime = _generateInterval;
        }

        public override void UpdateStage()
        {
            if (!(_generateCount < _count)) return;
            
            _currentGenerateTime -= Time.deltaTime;
            if (!(_currentGenerateTime <= 0)) return;
            
            GenerateEnemy();
            _generateCount++;
            _currentGenerateTime = _generateInterval;
        }

        private void GenerateEnemy()
        {
            switch (_enemyType)
            {
                case EnemyType.Elf:
                    FactoryManager.EnemyFactory.CreateCharacter<Elf>(_weaponType, _position);
                    break;
                case EnemyType.Ogre:
                    FactoryManager.EnemyFactory.CreateCharacter<Ogre>(_weaponType, _position);
                    break;
                case EnemyType.Troll:
                    FactoryManager.EnemyFactory.CreateCharacter<Troll>(_weaponType, _position);
                    break;
                default:
                    Debug.LogError($"无法生成{_enemyType}类型的敌人");
                    break;
            }
        }
    }
}