using System.Collections.Generic;
using GameSystems.CharacterSystem.Visitor;
using Pattern.FacadeAndSingletonPattern;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystems.UserInterfaceSystem
{
    public class GameStateInfoUI : UserInterface
    {
        private List<GameObject> _hearts;
        private Text _soliderCount;
        private Text _enemyCount;
        private Text _stageLevel;
        private Button _pauseBtn;
        private Slider _energy;
        private Text _energyText;
        private GameObject _gameOver;
        private Button _backToMenu;
        private Text _message;

        private float _messageTime = 2;
        private float _currentMessageTime = 0;

        public override void Init()
        {
            rootUI = UnityTools.FindChild(GameObject.Find("Canvas"), "GameStateInfo");

            var heart1 = UiTool.Find<GameObject>(rootUI, "Heart1");
            var heart2 = UiTool.Find<GameObject>(rootUI, "Heart2");
            var heart3 = UiTool.Find<GameObject>(rootUI, "Heart3");
            _hearts = new List<GameObject> { heart1, heart2, heart3 };
            _soliderCount = UiTool.Find<Text>(rootUI, "SoliderCount");
            _enemyCount = UiTool.Find<Text>(rootUI, "EnemyCount");
            _stageLevel = UiTool.Find<Text>(rootUI, "StageLevel");
            _pauseBtn = UiTool.Find<Button>(rootUI, "PauseBtn");
            _energy = UiTool.Find<Slider>(rootUI, "Energy");
            _energyText = UiTool.Find<Text>(rootUI, "EnergyText");
            _gameOver = UnityTools.FindChild(rootUI, "GameOver");
            _backToMenu = UiTool.Find<Button>(rootUI, "BackToMenu");
            _message = UiTool.Find<Text>(rootUI, "Message");

            _message.text = "";
            _gameOver.SetActive(false);
        }

        public override void Update()
        {
            base.Update();
            if (_currentMessageTime > 0)
            {
                _currentMessageTime -= Time.deltaTime;
                if (_currentMessageTime <= 0)
                {
                    _message.text = "";
                }
            }
        }

        public void ShowMessage(string msg)
        {
            _message.text = msg;
            _currentMessageTime = _messageTime;
        }

        public void UpdateEnergySlider(float currentEnergy,float maxEnergy)
        {
            _energy.value = currentEnergy / maxEnergy;
            _energyText.text = $"({currentEnergy}/{maxEnergy})";
        }

        public void UpdateLiveInfo(int soliderLiveCount,int enemyLiveCount)
        {
            _soliderCount.text = soliderLiveCount.ToString();
            _enemyCount.text = enemyLiveCount.ToString();
        }
    }
}