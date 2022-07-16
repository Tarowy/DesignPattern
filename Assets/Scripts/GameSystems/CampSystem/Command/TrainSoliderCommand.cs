using Factory;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;

namespace GameSystems.CampSystem.Command
{
    /// <summary>
    /// 命令模式（Command Pattern）是一种数据驱动的设计模式，它属于行为型模式。
    /// 请求以命令的形式包裹在对象中，并传给调用对象。
    /// 调用对象寻找可以处理该命令的合适的对象，并把该命令传给相应的对象，该对象执行命令。
    /// https://www.runoob.com/design-pattern/command-pattern.html
    /// </summary>
    public class TrainSoliderCommand: TrainCampCommand
    {
        private SoliderType _soliderType;
        private WeaponType _weaponType;
        private Vector3 _spawnPosition;
        private int _level;

        public TrainSoliderCommand(SoliderType soliderType, WeaponType weaponType, Vector3 spawnPosition, int level)
        {
            _soliderType = soliderType;
            _weaponType = weaponType;
            _spawnPosition = spawnPosition;
            _level = level;
        }
        
        public override void Execute()
        {
            switch (_soliderType)
            {
                case SoliderType.Rookie:
                    FactoryManager.SoliderFactory.CreateCharacter<Rookie>(_weaponType, _spawnPosition, _level);
                    break;
                case SoliderType.Sergeant:
                    FactoryManager.SoliderFactory.CreateCharacter<Sergeant>(_weaponType, _spawnPosition, _level);
                    break;
                case SoliderType.Captain:
                    FactoryManager.SoliderFactory.CreateCharacter<Captain>(_weaponType, _spawnPosition, _level);
                    break;
                default:
                    Debug.LogError($"无法执行Solider类型为{_soliderType}的命令");
                    break;
            }
        }
    }
}