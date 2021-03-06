using Factory;
using GameSystems.CampSystem;
using Pattern.FacadeAndSingletonPattern;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using Weapon;

namespace GameSystems.UserInterfaceSystem
{
    public class CampInfoUI : UserInterface
    {
        private Camp _camp;

        private Image _campImg;
        private Text _campName;
        private Text _campLevel;
        private Text _weaponLevel;
        private Button _upgradeCamp;
        private Button _upgradeWeapon;
        private Button _trainSolider;
        private Text _trainSoliderText;
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
            _trainSoliderText = _trainSolider.transform.GetChild(0).GetComponent<Text>();

            _trainSolider.onClick.AddListener(OnTrainClick);
            _cancelTrain.onClick.AddListener(OnCancelTrain);
            _upgradeCamp.onClick.AddListener(OnCampUpgradeClick);
            _upgradeWeapon.onClick.AddListener(OnWeaponUpgradeClick);

            Hide();
        }

        public override void Update()
        {
            base.Update();
            if (_camp is not null)
            {
                UpdateCampInfo();
            }
        }

        public void ShowCampInfo(Camp camp)
        {
            Show();
            _camp = camp;
            _campImg.sprite = FactoryManager.AssetFactory.LoadSprite(camp.CampSprite);
            _campLevel.text = camp.Level.ToString();
            _campName.text = camp.CampName;
            _trainSoliderText.text = $"????????????\n{camp.TrainCost}?????????";
            _weaponLevel.text = camp.WeaponType switch
            {
                WeaponType.Gun => "??????",
                WeaponType.Rifle => "??????",
                WeaponType.Rocket => "??????",
                _ => _weaponLevel.text
            };
        }

        public void UpdateCampInfo()
        {
            _trainingTime.text = _camp.TrainLeftTime.ToString("0.00");
            _trainingCount.text = _camp.CommandCount.ToString();

            if (_camp.CommandCount <= 0)
            {
                _cancelTrain.interactable = false;
                return;
            }

            _cancelTrain.interactable = true;
        }

        private void OnTrainClick()
        {
            if (GameFacade.Instance.CostEnergy(_camp.TrainCost))
            {
                _camp.Train();
                return;
            }

            GameFacade.Instance.ShowMessage($"????????????{_camp.TrainCost}??????????????????????????????????????????");
        }

        private void OnCancelTrain()
        {
            GameFacade.Instance.RecycleEnergy(_camp.TrainCost);
            _camp.CancelTrain();
        }

        private void OnCampUpgradeClick()
        {
            var energy = _camp.CampUpgradeCost;
            if (energy <= 0)
            {
                GameFacade.Instance.ShowMessage("??????????????????????????????????????????");
                return;
            }

            if (GameFacade.Instance.CostEnergy(_camp.CampUpgradeCost))
            {
                _camp.UpgradeCamp();
                ShowCampInfo(_camp);
                return;
            }

            GameFacade.Instance.ShowMessage($"??????????????????{_camp.CampUpgradeCost}?????????????????????????????????");
        }

        private void OnWeaponUpgradeClick()
        {
            var energy = _camp.WeaponUpgradeCost;
            if (energy <= 0)
            {
                GameFacade.Instance.ShowMessage("??????????????????????????????????????????");
                return;
            }

            if (GameFacade.Instance.CostEnergy(_camp.WeaponUpgradeCost))
            {
                _camp.UpgradeWeapon();
                ShowCampInfo(_camp);
                return;
            }

            GameFacade.Instance.ShowMessage($"??????????????????{_camp.WeaponUpgradeCost}????????????????????????????????????");
        }
    }
}