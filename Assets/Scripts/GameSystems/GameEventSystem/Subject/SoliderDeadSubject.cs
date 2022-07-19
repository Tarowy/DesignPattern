namespace GameSystems.GameEventSystem.Subject
{
    public class SoliderDeadSubject: GameEventSubject
    {
        public int SoliderDeadCount { set; get; }

        public override void Notify()
        {
            SoliderDeadCount++;
            base.Notify();
        }
    }
}