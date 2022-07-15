using Tools;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

namespace GameSystems.UserInterfaceSystem
{
    public class CampInfoUI: UserInterface
    {
        private Image _campImg;
        private Text _campName;
        private Text _campLevel;
        private Text _weaponLevel;
        private Button _upgradeCamp;
        private Button _upgradeWeapon;
        private Button _trainSolider;
        private Button _cancelTrain;
        private Text _aliveCount;
        private Text _trainingCount;
        private Text _trainingTime;

        public override void Init()
        {
            rootUI = UnityTools.FindChild(GameObject.Find("Canvas"), "CampInfo");

            _campImg = UiTool.Find<Image>(rootUI, "CampIcon");
            _campLevel = UiTool.Find<Text>(rootUI, "CampLevel");
            _campName = UiTool.Find<Text>(rootUI, "CampName");
            _weaponLevel = UiTool.Find<Text>(rootUI, "WeaponLevel");
            _upgradeCamp = UiTool.Find<Button>(rootUI, "UpgradeCamp");
            _upgradeWeapon = UiTool.Find<Button>(rootUI, "UpgradeWeapon");
            _trainSolider = UiTool.Find<Button>(rootUI, "TrainSolider");
            _cancelTrain = UiTool.Find<Button>(rootUI, "CancelTrain");
            _aliveCount = UiTool.Find<Text>(rootUI, "AliveCount");
            _trainingCount = UiTool.Find<Text>(rootUI, "TrainingCount");
            _trainingTime = UiTool.Find<Text>(rootUI, "TrainingTime");
        }
    }
}