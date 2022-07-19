using GameSystems.GameEventSystem.Subject;

namespace GameSystems.GameEventSystem.Observer.SoliderDeadObserver
{
    public class SoliderDeadObAchieve: GameEventObserver
    {
        private AchievementSystem.AchievementSystem _achievementSystem;

        public SoliderDeadObAchieve(AchievementSystem.AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }
        
        public override void Update()
        {
            _achievementSystem.AddSoliderDeadCount();
        }

        public override void SetSubject(GameEventSubject subject)
        {
            
        }
    }
}