using GameSystems.GameEventSystem.Subject;

namespace GameSystems.GameEventSystem.Observer.EnemyDeadObserver
{
    public class EnemyDeadObAchieve : GameEventObserver
    {
        private readonly AchievementSystem.AchievementSystem _achievementSystem;

        public EnemyDeadObAchieve(AchievementSystem.AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }

        public override void Update()
        {
            _achievementSystem.AddEnemyDeadCount();
        }

        public override void SetSubject(GameEventSubject subject)
        {
            
        }
    }
}