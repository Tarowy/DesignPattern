using System.Collections.Generic;

namespace GameSystems.CharacterSystem
{
    public class CharacterSystem: IGameSystem
    {
        private List<Character> _soliders = new();
        private List<Character> _enemies = new();

        public void AddEnemy(Enemy.Enemy enemy) => _enemies.Add(enemy);
        public void RemoveEnemy(Enemy.Enemy enemy) => _enemies.Remove(enemy);

        public void AddSolider(Solider.Solider solider) => _soliders.Add(solider);
        public void RemoveSolider(Solider.Solider solider) => _soliders.Remove(solider);

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
    }
}