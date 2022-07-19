using GameSystems.GameEventSystem.Subject;

namespace GameSystems.GameEventSystem.Observer
{
    public abstract class GameEventObserver
    {
        public abstract void Update();
        public abstract void SetSubject(GameEventSubject subject);
    }
}