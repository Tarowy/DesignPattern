using GameSystems.AchievementSystem;
using GameSystems.CampSystem;
using GameSystems.CharacterSystem;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using GameSystems.EnergySystem;
using GameSystems.GameEventSystem;
using GameSystems.StageSystem;
using GameSystems.UserInterfaceSystem;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Pattern.FacadeAndSingletonPattern
{
    /// <summary>
    /// 外观模式（Facade Pattern）隐藏系统的复杂性，并向客户端提供了一个客户端可以访问系统的接口。
    /// 这种类型的设计模式属于结构型模式，它向现有的系统添加一个接口，来隐藏系统的复杂性。
    /// 这种模式涉及到一个单一的类，该类提供了客户端请求的简化方法和对现有系统类方法的委托调用。
    /// https://www.runoob.com/design-pattern/facade-pattern.html
    ///
    /// 中介者模式（Mediator Pattern）是用来降低多个对象和类之间的通信复杂性。
    /// 这种模式提供了一个中介类，该类通常处理不同类之间的通信，并支持松耦合，使代码易于维护。中介者模式属于行为型模式。
    /// https://www.runoob.com/design-pattern/mediator-pattern.html
    ///
    /// 两者区别：
    /// 外观模式是外部模块通过Facade调用复杂的子系统的逻辑
    /// 中介者模式是子系统之间通过Mediator来相互访问
    /// </summary>
    public class GameFacade
    {
        //单例模式： https://www.runoob.com/design-pattern/singleton-pattern.html
        public static GameFacade Instance = new();
        private bool _gameOver;
        public bool GameOver => _gameOver;

        private AchievementSystem _achievementSystem = new();
        private CampSystem _campSystem = new();
        private CharacterSystem _characterSystem = new();
        private EnergySystem _energySystem = new();
        private GameEventSystem _gameEventSystem = new();
        private StageSystem _stageSystem = new();

        private CampInfoUI _campInfoUI = new();
        private GamePauseUI _gamePauseUI = new();
        private GameStateInfoUI _stateInfoUI = new();
        private SoliderInfoUI _soliderInfoUI = new();

        public void Init()
        {
            _achievementSystem.Init();
            _campSystem.Init();
            _characterSystem.Init();
            _energySystem.Init();
            _gameEventSystem.Init();
            _stageSystem.Init();

            _campInfoUI.Init();
            _gamePauseUI.Init();
            _stateInfoUI.Init();
            _soliderInfoUI.Init();
        }

        public void Update()
        {
            _achievementSystem.Update();
            _campSystem.Update();
            _characterSystem.Update();
            _energySystem.Update();
            _gameEventSystem.Update();
            _stageSystem.Update();

            _campInfoUI.Update();
            _gamePauseUI.Update();
            _stateInfoUI.Update();
            _soliderInfoUI.Update();
        }

        public void Release()
        {
            _achievementSystem.Release();
            _campSystem.Release();
            _characterSystem.Release();
            _energySystem.Release();
            _gameEventSystem.Release();
            _stageSystem.Release();

            _campInfoUI.Release();
            _gamePauseUI.Release();
            _stateInfoUI.Release();
            _soliderInfoUI.Release();
        }

        public Vector3 GetEnemyTargetPosition()
        {
            return Vector3.zero;
        }

        public void ShowCampInfo(Camp camp)
        {
            _campInfoUI.ShowCampInfo(camp);
        }

        public void AddSolider(Solider solider)
        {
            _characterSystem.AddSolider(solider);
        }

        public void AddEnemy(Enemy enemy)
        {
            _characterSystem.AddEnemy(enemy);
        }

        public bool CostEnergy(float value)
        {
            return _energySystem.CostEnergy(value);
        }

        public void ShowMessage(string msg)
        {
            _stateInfoUI.ShowMessage(msg);
        }

        public void RecycleEnergy(float value)
        {
            _energySystem.RecycleEnergy(value);
        }
        
        public void UpdateEnergySlider(float currentEnergy,float maxEnergy)
        {
            _stateInfoUI.UpdateEnergySlider(currentEnergy, maxEnergy);
        }
    }
}