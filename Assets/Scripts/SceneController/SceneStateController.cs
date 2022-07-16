using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneController
{
    public class SceneStateController
    {
        private SceneState _state;
        private AsyncOperation _asyncOperation;
        private bool _loadDone;

        public void SetState(SceneState state, bool loadScene = true)
        {
            // Debug.Log("切换场景");
            if (state is null)
            {
                return;
            }
            
            _state?.StateEnd();
            _state = state;

            //游戏刚开始时，第一个场景不需要加载，所以得区分对待
            if (!loadScene)
            {
                _state.StateStart();
                _loadDone = true;
                return;
            }

            _asyncOperation = SceneManager.LoadSceneAsync(_state.SceneName);
            _loadDone = false;
        }

        public void StateUpdate()
        {
            /*
             * 异步场景加载为空或者场景没有加载完
             *  1.这是第一个场景，asyncOperation为null，但loadScene是true，不return，直接指向update
             *  2.不是第一个场景，asyncOperation不为null，且场景没有加载完，loadScene也是false，不return
             */
            if (_asyncOperation is null || !_asyncOperation.isDone)
            {
                if (!_loadDone)
                {
                    return;
                }
            }

            if (!_loadDone && _asyncOperation.isDone)
            {
                Debug.Log($"战斗场景Start {_loadDone}");
                _loadDone = true;
                _state.StateStart();
                return;
            }

            _state.StateUpdate();
        }
    }
}