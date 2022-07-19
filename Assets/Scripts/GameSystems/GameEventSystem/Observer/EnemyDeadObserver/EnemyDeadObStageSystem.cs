using GameSystems.GameEventSystem.Subject;

namespace GameSystems.GameEventSystem.Observer.EnemyDeadObserver
{
    public class EnemyDeadObStageSystem: GameEventObserver
    {
        private readonly StageSystem.StageSystem _stageSystem; //当观察到敌人死亡后会通知场景系统
        private EnemyDeadSubject _subject;

        public EnemyDeadObStageSystem(StageSystem.StageSystem stageSystem)
        {
            _stageSystem = stageSystem;
        }
        
        public override void Update()
        {
            //更新场景中敌人死亡的数量
            _stageSystem.EnemyDeadCount = _subject.EnemyDeadCount;
        }

        public override void SetSubject(GameEventSubject subject)
        {
            _subject = subject as EnemyDeadSubject;
        }
    }
}