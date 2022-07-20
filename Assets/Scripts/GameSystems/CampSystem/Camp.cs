using System.Collections.Generic;
using GameSystems.CampSystem.Command;
using GameSystems.CharacterSystem.Solider;
using GameSystems.EnergySystem.EnergyStrategy;
using UnityEngine;
using Weapon;

namespace GameSystems.CampSystem
{
    public abstract class Camp
    {
        protected string campName; //兵营名称
        protected string campSprite; //兵营图片
        protected GameObject prefab; //兵营的实体
        protected SoliderType soliderType; //根据类型和等级获得能量耗费
        protected Vector3 musterPosition; //兵营生产出的士兵位置
        protected float trainTime;

        protected float trainLeftTime;
        protected Queue<TrainCampCommand> commands; //命令模式
        
        //能量花费不是一直变动的，所以可以直接保存花费的变量减少策略的调用次数
        protected EnergyCostStrategy energyCostStrategy;
        protected int campUpgradeCost;
        protected int weaponUpgradeCost;
        protected int trainCost;

        protected Camp(string campName, string campSprite, GameObject prefab, SoliderType soliderType,
            Vector3 musterPosition,float trainTime)
        {
            this.campName = campName;
            this.campSprite = campSprite;
            this.prefab = prefab;
            this.soliderType = soliderType;
            this.musterPosition = musterPosition;
            this.trainTime = trainTime;

            trainLeftTime = this.trainTime;
            commands = new Queue<TrainCampCommand>();
        }
        
        public void Update()
        {
            UpdateTrainTime();
        }

        private void UpdateTrainTime()
        {
            if (commands.Count <= 0)
            {
                return;
            }

            trainLeftTime -= Time.deltaTime;

            if (trainLeftTime <= 0)
            {
                Debug.Log($"{soliderType}训练完毕");
                commands.Dequeue().Execute();
                trainLeftTime = trainTime;
            }
        }

        public string CampName => campName;
        public string CampSprite => campSprite;
        public GameObject Prefab => prefab;
        public SoliderType SoliderType => soliderType;
        public Vector3 MusterPosition => musterPosition;
        public float TrainTime => trainTime;
        
        public abstract int Level { get; }
        public abstract WeaponType WeaponType { get; }
        public abstract int CampUpgradeCost { get; }
        public abstract int WeaponUpgradeCost { get; }
        public abstract int TrainCost { set; get; }

        public int CommandCount => commands.Count;
        public float TrainLeftTime => trainLeftTime;

        public abstract void Train();
        public abstract void UpdateEnergyCost();
        public abstract void UpgradeCamp();
        public abstract void UpgradeWeapon();

        public virtual void CancelTrain()
        {
            if (commands.Count == 0)
            {
                return;
            }
            Debug.Log("取消训练");
            commands.Dequeue();
            //命令为0时需要重置训练时间
            if (commands.Count == 0)
            {
                trainLeftTime = trainTime;
            }
        }
    }
}