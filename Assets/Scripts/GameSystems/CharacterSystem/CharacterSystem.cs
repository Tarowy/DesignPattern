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
            foreach (var solider in _soliders)
            {
                solider.Update();
                solider.UpdateFsmAI(_enemies);
            }

            foreach (var enemy in _enemies)
            {
                enemy.Update();
                enemy.UpdateFsmAI(_soliders);
            }
        }

        public void Release()
        {
        }
    }
}