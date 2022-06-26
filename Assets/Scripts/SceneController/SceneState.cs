namespace SceneController
{
    /// <summary>
    /// 场景状态模式，用来切换不同的场景状态
    /// </summary>
    public abstract class SceneState
    {
        private string _sceneName;
        protected SceneStateController sceneStateController;

        public SceneState(string sceneName,SceneStateController sceneStateController)
        {
            _sceneName = sceneName;
            this.sceneStateController = sceneStateController;
        }

        public string SceneName => _sceneName;

        public virtual void StateStart()
        {
        }

        public virtual void StateUpdate()
        {
        }

        public virtual void StateEnd()
        {
        }
    }
}