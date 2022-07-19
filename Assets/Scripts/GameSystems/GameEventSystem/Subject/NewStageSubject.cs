namespace GameSystems.GameEventSystem.Subject
{
    public class NewStageSubject: GameEventSubject
    {
        public int StageCount { set; get; }
        
        public override void Notify()
        {
            StageCount++;
            base.Notify();
        }
    }
}