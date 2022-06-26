using StatePattern;
using UnityEngine;
using UnityEngine.UI;

namespace SceneController
{
    public class StartSceneState : SceneState
    {
        private Image _logo;
        private float smooth = 2f;
        private float changeSceneTime = 2f;

        public StartSceneState(SceneStateController sceneStateController) : base("01StartScene", sceneStateController)
        {
        }

        public override void StateStart()
        {
            _logo = GameObject.Find("Logo").GetComponent<Image>();
            _logo.color = Color.black;
        }

        public override void StateUpdate()
        {
            _logo.color = Color.Lerp(_logo.color, Color.white, smooth * Time.deltaTime);
            changeSceneTime -= Time.deltaTime;
            //计时结束后切换到主菜单
            if (changeSceneTime <= 0)
            {
                sceneStateController.SetState(new MainMenuSceneState(sceneStateController));
            }
        }

        public override void StateEnd()
        {
        }
    }
}