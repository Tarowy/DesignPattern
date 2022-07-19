using GameSystems.GameEventSystem.Subject;

namespace GameSystems.GameEventSystem.Observer.NewStageObserver
{
    public class NewStageObAchieve: GameEventObserver
    {
        private AchievementSystem.AchievementSystem _achievementSystem;
        private NewStageSubject _subject;

        public NewStageObAchieve(AchievementSystem.AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }
        
        public override void Update()
        {
            _achievementSystem.SetMaxStageLevel(_subject.StageCount);
        }

        public override void SetSubject(GameEventSubject subject)
        {
            _subject = subject as NewStageSubject;
        }
    }
}