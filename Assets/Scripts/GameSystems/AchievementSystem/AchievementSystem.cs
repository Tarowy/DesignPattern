using GameSystems.GameEventSystem;
using GameSystems.GameEventSystem.Observer.EnemyDeadObserver;
using GameSystems.GameEventSystem.Observer.NewStageObserver;
using GameSystems.GameEventSystem.Observer.SoliderDeadObserver;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;

namespace GameSystems.AchievementSystem
{
    public class AchievementSystem: IGameSystem
    {
        private int _enemyDeadCunt;
        private int _soliderDeadCount;
        private int _maxStageLevel = 1;

        public void AddEnemyDeadCount(int num = 1)
        {
            _enemyDeadCunt += num;
            Debug.Log($"成就系统更新：Enemy {_enemyDeadCunt}");
        }

        public void AddSoliderDeadCount(int num = 1)
        {
            _soliderDeadCount += num;
            Debug.Log($"成就系统更新：Solider {_soliderDeadCount}");
        }

        public void SetMaxStageLevel(int level)
        {
            _maxStageLevel = Mathf.Max(level, _maxStageLevel);
            Debug.Log($"成就系统更新：Stage {_maxStageLevel}");
        }
        
        public void Init()
        {
            //当观察者观察到敌人死亡，观察者就会更新敌人的死亡人数
            GameFacade.Instance.RegisterObserver(GameEventType.EnemyDead,new EnemyDeadObAchieve(this));
            GameFacade.Instance.RegisterObserver(GameEventType.SoliderDead, new SoliderDeadObAchieve(this));
            GameFacade.Instance.RegisterObserver(GameEventType.NewStage, new NewStageObAchieve(this));
        }

        public void Update()
        {
        }

        public void Release()
        {
        }

        /// <summary>
        /// 储存当前的存档数据
        /// </summary>
        /// <returns>含有当前成就数据的AchieveMemento对象</returns>
        public AchieveMemento CreateMemento()
        {
            return new AchieveMemento
            {
                EnemyDeadCount = _enemyDeadCunt,
                SoliderDeadCount = _soliderDeadCount,
                MaxStageLevel = _maxStageLevel
            };
        }

        /// <summary>
        /// 将成就数据读取出来
        /// </summary>
        /// <param name="memento"></param>
        public void SetMemento(AchieveMemento memento)
        {
            _enemyDeadCunt = memento.EnemyDeadCount;
            _soliderDeadCount = memento.SoliderDeadCount;
            _maxStageLevel = memento.MaxStageLevel;
        }
    }
}