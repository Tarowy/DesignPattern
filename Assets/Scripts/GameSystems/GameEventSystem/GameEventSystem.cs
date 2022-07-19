using System.Collections.Generic;
using GameSystems.GameEventSystem.Observer;
using GameSystems.GameEventSystem.Subject;
using UnityEngine;

namespace GameSystems.GameEventSystem
{
    public enum GameEventType
    {
        Null,
        SoliderDead,
        EnemyDead,
        NewStage
    }

    public class GameEventSystem : IGameSystem
    {
        private Dictionary<GameEventType, GameEventSubject> _eventSubjects = new();

        public void Init()
        {
            
        }

        private void InitSubjects()
        {
            _eventSubjects = new Dictionary<GameEventType, GameEventSubject>
            {
                {
                    GameEventType.SoliderDead, new SoliderDeadSubject()
                },
                {
                    GameEventType.EnemyDead, new EnemyDeadSubject()
                },
                {
                    GameEventType.NewStage, new NewStageSubject()
                }
            };
        }

        private GameEventSubject GetSubject(GameEventType eventType)
        {
            //在使用的时候才需要进行初始化，如果在Init直接初始化可能会导致还未初始化前就被调用导致报错
            if (!_eventSubjects.ContainsKey(eventType))
            {
                switch (eventType)
                {
                    case GameEventType.SoliderDead:
                        _eventSubjects.Add(eventType,new SoliderDeadSubject());
                        break;
                    case GameEventType.EnemyDead:
                        _eventSubjects.Add(eventType,new EnemyDeadSubject());
                        break;
                    case GameEventType.NewStage:
                        _eventSubjects.Add(eventType,new NewStageSubject());
                        break;
                    default:
                        Debug.LogError($"没有{eventType}这个类型");
                        return null;
                }
            }
            
            return _eventSubjects[eventType];
        }

        /// <summary>
        /// 添加观察者
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="observer">观察者</param>
        public void RegisterObserver(GameEventType eventType, GameEventObserver observer)
        {
            var gameEventSubject = GetSubject(eventType);

            gameEventSubject?.RegisterObserver(observer);
            observer.SetSubject(gameEventSubject);
        }

        /// <summary>
        /// 移除其中一个观察者
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="observer"></param>
        public void RemoveObserver(GameEventType eventType, GameEventObserver observer)
        {
            var gameEventSubject = GetSubject(eventType);

            gameEventSubject?.RemoveObserver(observer);
            observer.SetSubject(null);
        }

        /// <summary>
        /// 通知所有观察者
        /// </summary>
        /// <param name="eventType"></param>
        public void NotifySubject(GameEventType eventType)
        {
            var gameEventSubject = GetSubject(eventType);
            
            gameEventSubject?.Notify();
        }

        public void Update()
        {
        }

        public void Release()
        {
        }
    }
}