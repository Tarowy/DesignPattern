using System.Collections.Generic;
using GameSystems.CharacterSystem.Visitor;
using Pattern.FacadeAndSingletonPattern;

namespace GameSystems.CharacterSystem
{
    public class CharacterSystem: IGameSystem
    {
        private List<Character> _soliders = new();
        private List<Character> _enemies = new();

        private AliveCountVisitor _aliveCountVisitor = new();

        public void AddEnemy(Enemy.Enemy enemy)
        {
            _enemies.Add(enemy);
            _aliveCountVisitor.Reset();
            RunVisitor(_aliveCountVisitor);
            GameFacade.Instance.UpdateLiveInfo(_aliveCountVisitor.SoliderLiveCount,_aliveCountVisitor.EnemyLiveCount);
        }

        public void RemoveEnemy(Enemy.Enemy enemy)
        {
            _enemies.Remove(enemy);
            _aliveCountVisitor.Reset();
            RunVisitor(_aliveCountVisitor);
            GameFacade.Instance.UpdateLiveInfo(_aliveCountVisitor.SoliderLiveCount,_aliveCountVisitor.EnemyLiveCount);
        }

        public void AddSolider(Solider.Solider solider)
        {
            _soliders.Add(solider);
            _aliveCountVisitor.Reset();
            RunVisitor(_aliveCountVisitor);
            GameFacade.Instance.UpdateLiveInfo(_aliveCountVisitor.SoliderLiveCount,_aliveCountVisitor.EnemyLiveCount);
        }

        public void RemoveSolider(Solider.Solider solider)
        {
            _soliders.Remove(solider);
            _aliveCountVisitor.Reset();
            RunVisitor(_aliveCountVisitor);
            GameFacade.Instance.UpdateLiveInfo(_aliveCountVisitor.SoliderLiveCount,_aliveCountVisitor.EnemyLiveCount);
        }
        

        public void Init()
        {
            
        }

        public void Update()
        {
            UpdateSolider();
            UpdateEnemy();
        }

        private void UpdateSolider()
        {
            if (_soliders.Count == 0)
            {
                return;
            }
            //不能使用foreach，foreach遍历时如果有士兵或敌人死亡会造成迭代变量被改变而抛出异常
            for (var i = 0; i < _soliders.Count; i++)
            {
                _soliders[i].Update();
                _soliders[i].UpdateFsmAI(_enemies);
            }
        }

        private void UpdateEnemy()
        {
            if (_enemies.Count == 0)
            {
                return;
            }
            for (var i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Update();
                _enemies[i].UpdateFsmAI(_soliders);
            }
        }

        public void Release()
        {
            
        }

        public void RunVisitor(CharacterVisitor characterVisitor)
        {
            foreach (var solider in _soliders)
            {
                solider.RunVisitor(characterVisitor);
            }

            foreach (var enemy in _enemies)
            {
                enemy.RunVisitor(characterVisitor);
            }
        }
    }
}