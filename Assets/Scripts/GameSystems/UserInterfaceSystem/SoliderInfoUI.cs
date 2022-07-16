using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystems.UserInterfaceSystem
{
    public class SoliderInfoUI : UserInterface
    {
        private Image _soliderIcon;
        private Text _soliderName;
        private Text _healthNumber;
        private Slider _healthSlider;
        private Text _level;
        private Text _attack;
        private Text _speed;
        private Text _range;

        public override void Init()
        {
            rootUI = UnityTools.FindChild(GameObject.Find("Canvas"), "SoliderInfo");

            _soliderIcon = UiTool.Find<Image>(rootUI, "SoliderIcon");
            _soliderName = UiTool.Find<Text>(rootUI, "SoliderName");
            _healthNumber = UiTool.Find<Text>(rootUI, "HealthNumber");
            _healthSlider = UiTool.Find<Slider>(rootUI, "HealthSlider");
            _level = UiTool.Find<Text>(rootUI, "Level");
            _attack = UiTool.Find<Text>(rootUI, "Attack");
            _speed = UiTool.Find<Text>(rootUI, "Speed");
            _range = UiTool.Find<Text>(rootUI, "Range");
            
            Hide();
        }
    }
}