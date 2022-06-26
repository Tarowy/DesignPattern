using Pattern.FacadeAndSingletonPattern;

namespace SceneController
{
    public class BattleSceneState : SceneState
    {
        //外观模式的接口，由它来控制复杂的子系统
        // private GameFacade _gameFacade;
        
        public BattleSceneState(SceneStateController sceneStateController) : base("03BattleScene", sceneStateController)
        {
            
        }

        public override void StateStart()
        {
            GameFacade.Instance.Init();
        }

        public override void StateUpdate()
        {
            GameFacade.Instance.Update();
        }

        public override void StateEnd()
        {
            if (GameFacade.Instance.GameOver)
            {
                sceneStateController.SetState(new StartSceneState(sceneStateController));
                return;
            }
            
            GameFacade.Instance.Update();
        }
    }
}