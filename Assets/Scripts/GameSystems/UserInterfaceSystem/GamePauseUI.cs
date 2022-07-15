using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystems.UserInterfaceSystem
{
    public class GamePauseUI : UserInterface
    {
        private Text _stageLevel;
        private Button _continueBtn;
        private Button _menuBtn;
        

        public override void Init()
        {
            rootUI = UnityTools.FindChild(GameObject.Find("Canvas"), "GamePause");

            _stageLevel = UiTool.Find<Text>(rootUI, "StageLevel");
            _continueBtn = UiTool.Find<Button>(rootUI, "ContinueBtn");
            _menuBtn = UiTool.Find<Button>(rootUI, "MenuBtn");
        }
    }
}