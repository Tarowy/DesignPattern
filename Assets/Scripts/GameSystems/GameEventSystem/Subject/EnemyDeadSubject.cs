namespace GameSystems.GameEventSystem.Subject
{
    public class EnemyDeadSubject: GameEventSubject
    {
        public int EnemyDeadCount { set; get; } = 0;

        public override void Notify()
        {
            EnemyDeadCount++;
            base.Notify();
        }
    }
}