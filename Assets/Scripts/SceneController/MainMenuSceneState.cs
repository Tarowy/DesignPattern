using UnityEngine;
using UnityEngine.UI;


namespace SceneController
{
    public class MainMenuSceneState: SceneState
    {
        private Button _startButton;
        
        public MainMenuSceneState(SceneStateController sceneStateController) : base("02MainMenuScene", sceneStateController)
        {
            
        }

        public override void StateStart()
        {
            _startButton = GameObject.Find("StartButton").GetComponent<Button>();
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            Debug.Log("加载场景");
            sceneStateController.SetState(new BattleSceneState(sceneStateController));
        }
    }
}