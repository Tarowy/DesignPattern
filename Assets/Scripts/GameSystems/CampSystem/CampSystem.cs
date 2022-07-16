using System;
using System.Collections.Generic;
using GameSystems.CharacterSystem.Solider;
using MonoBe;
using Tools;
using UnityEngine;

namespace GameSystems.CampSystem
{
    public class CampSystem : IGameSystem
    {
        private Dictionary<SoliderType, SoliderCamp> _camps;

        public void Init()
        {
            InitCamp();
        }

        private void InitCamp()
        {
            var gameObject = GameObject.Find("SoliderCamp_Rookie");
            
            var rookieCamp = new SoliderCamp("下士兵营", "RookieCamp",
                gameObject, SoliderType.Rookie,
                UnityTools.FindChild(gameObject, "TrainPoint").transform.position, 3);
            gameObject.AddComponent<CampClick>().Camp = rookieCamp;

            gameObject = GameObject.Find("SoliderCamp_Sergeant");
            var sergeantCamp = new SoliderCamp("中士兵营", "SergeantCamp",
                gameObject, SoliderType.Sergeant,
                UnityTools.FindChild(gameObject, "TrainPoint").transform.position, 4);
            gameObject.AddComponent<CampClick>().Camp = sergeantCamp;

            gameObject = GameObject.Find("SoliderCamp_Captain");
            var captainCamp = new SoliderCamp("上士兵营", "CaptainCamp",
                gameObject, SoliderType.Captain,
                UnityTools.FindChild(gameObject, "TrainPoint").transform.position, 5);
            gameObject.AddComponent<CampClick>().Camp = captainCamp;

            _camps = new Dictionary<SoliderType, SoliderCamp>
            {
                {
                    SoliderType.Rookie, rookieCamp
                },
                {
                    SoliderType.Sergeant, sergeantCamp
                },
                {
                    SoliderType.Captain, captainCamp
                }
            };
        }

        public void Update()
        {
            foreach (var camp in _camps.Values)
            {
                camp.Update();
            }
        }

        public void Release()
        {
        }
    }
}