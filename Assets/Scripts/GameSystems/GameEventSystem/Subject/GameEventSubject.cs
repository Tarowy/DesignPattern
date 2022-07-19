using System.Collections.Generic;
using GameSystems.GameEventSystem.Observer;

namespace GameSystems.GameEventSystem.Subject
{
    /// <summary>
    /// 当对象间存在一对多关系时，则使用观察者模式（Observer Pattern）。
    /// 比如，当一个对象被修改时，则会自动通知依赖它的对象。
    /// 观察者模式属于行为型模式。
    /// https://www.runoob.com/design-pattern/observer-pattern.html
    /// </summary>
    public class GameEventSubject
    {
        private List<GameEventObserver> _observers;

        public GameEventSubject()
        {
            _observers = new List<GameEventObserver>();
        }

        public void RegisterObserver(GameEventObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(GameEventObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}