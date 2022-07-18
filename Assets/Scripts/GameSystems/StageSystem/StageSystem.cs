using System.Collections.Generic;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.StageSystem.Handler;
using UnityEngine;
using Weapon;

namespace GameSystems.StageSystem
{
    public class StageSystem : IGameSystem
    {
        private int _level = 1;
        private List<Vector3> _posList;
        private StageHandler _rootHandler;

        public Vector3 TargetPosition { set; get; }

        public void Init()
        {
            InitSpawnPosition();
            InitStageChain();
        }

        private void InitSpawnPosition()
        {
            _posList = new List<Vector3>();
            for (var i = 1; i <= 3; i++)
            {
                var pos = GameObject.Find($"Position{i}");
                if (pos is not null)
                {
                    _posList.Add(pos.transform.position);
                    pos.SetActive(false);
                }
            }

            TargetPosition = GameObject.Find("TargetPosition").transform.position;
        }

        private Vector3 GetRandomPos()
        {
            return _posList[Random.Range(0, _posList.Count)];
        }

        private void InitStageChain()
        {
            var level = 1;
            var normalStageHandler1 =
                new NormalStageHandler(level++, 3, EnemyType.Elf,
                    WeaponType.Gun, 3, GetRandomPos(), this);
            var normalStageHandler2 =
                new NormalStageHandler(level++, 5, EnemyType.Ogre,
                    WeaponType.Rifle, 7, GetRandomPos(), this);
            var normalStageHandler3 =
                new NormalStageHandler(level, 7, EnemyType.Troll,
                    WeaponType.Rocket, 11, GetRandomPos(), this);

            normalStageHandler1.SetNextStageHandler(normalStageHandler2).SetNextStageHandler(normalStageHandler3);
            _rootHandler = normalStageHandler1;
        }

        public void Update()
        {
            _rootHandler.Handle(_level);
        }

        public void Release()
        {
        }

        public int GetCountOfEnemyDead()
        {
            return 0;
        }

        public void EnterNextStage()
        {
            _level++;
        }
    }
}