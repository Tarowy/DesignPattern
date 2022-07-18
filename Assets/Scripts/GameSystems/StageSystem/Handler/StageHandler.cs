namespace GameSystems.StageSystem.Handler
{
    /// <summary>
    /// 顾名思义，责任链模式（Chain of Responsibility Pattern）为请求创建了一个接收者对象的链。
    /// 这种模式给予请求的类型，对请求的发送者和接收者进行解耦。这种类型的设计模式属于行为型模式。
    /// 在这种模式中，通常每个接收者都包含对另一个接收者的引用。
    /// 如果一个对象不能处理该请求，那么它会把相同的请求传给下一个接收者，依此类推。
    /// https://www.runoob.com/design-pattern/chain-of-responsibility-pattern.html
    /// </summary>
    public abstract class StageHandler
    {
        protected int level;
        protected int finishCount; //需要干掉多少个敌人才能进入下一关
        protected StageSystem stageSystem;

        private StageHandler _nextStageHandler; //下一个责任链

        public StageHandler(int level,int finishCount,StageSystem stageSystem)
        {
            this.level = level;
            this.finishCount = finishCount;
            this.stageSystem = stageSystem;
        }
        
        /// <summary>
        /// 设置下一个责任链，返回值返回下一个责任链的对象可以实现链式编程
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public StageHandler SetNextStageHandler(StageHandler handler)
        {
            _nextStageHandler = handler;
            return _nextStageHandler;
        }

        public void Handle(int levelHandle)
        {
            if (level == levelHandle)
            {
                UpdateStage();
                CheckStageFinished();
                return;
            }

            _nextStageHandler.Handle(levelHandle);
        }

        public abstract void UpdateStage();

        public void CheckStageFinished()
        {
            if (stageSystem.GetCountOfEnemyDead() >= finishCount)
            {
                stageSystem.EnterNextStage();
            }
        }
    }
}