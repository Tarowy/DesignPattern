using GameSystems.CampSystem.Command;
using GameSystems.CharacterSystem.Solider;
using GameSystems.EnergySystem.EnergyStrategy;
using UnityEngine;
using Weapon;

namespace GameSystems.CampSystem
{
    public class SoliderCamp : Camp
    {
        private const int MaxLevel = 4;
        private int _level = 1;
        private WeaponType _weaponType = WeaponType.Gun;

        public SoliderCamp(string campName, string campSprite, GameObject prefab,
            SoliderType soliderType, Vector3 musterPosition,
            float trainTime, WeaponType weaponType = WeaponType.Gun, int level = 1)
            : base(campName, campSprite, prefab, soliderType, musterPosition, trainTime)
        {
            _weaponType = weaponType;
            _level = level;

            energyCostStrategy = new SoliderCostStrategy();
            UpdateEnergyCost();
        }

        public override int Level => _level;
        public override WeaponType WeaponType => _weaponType;

        public override int CampUpgradeCost
        {
            get
            {
                if (_level == MaxLevel)
                {
                    return -1; //表示不可升级
                }

                return campUpgradeCost;
            }
        }

        public override int WeaponUpgradeCost
        {
            get
            {
                //Max是不存在的武器，下一个武器等级是Max说明该武器已经不可升级
                if (_weaponType + 1 == WeaponType.Max)
                {
                    return -1;
                }

                return weaponUpgradeCost;
            }
        }

        public override int TrainCost => trainCost;

        //训练士兵
        public override void Train()
        {
            Debug.Log("开始训练: " + soliderType);
            commands.Enqueue(new TrainSoliderCommand(soliderType, _weaponType, musterPosition, _level));
        }

        public sealed override void UpdateEnergyCost()
        {
            campUpgradeCost = energyCostStrategy.GetCampUpgradeCost(soliderType, _level);
            weaponUpgradeCost = energyCostStrategy.GetWeaponUpgradeCost(_weaponType);
            trainCost = energyCostStrategy.GetSoliderTrainCost(soliderType, _level);
        }

        public override void UpgradeCamp()
        {
            _level++;
            UpdateEnergyCost();
        }

        public override void UpgradeWeapon()
        {
            _weaponType++;
            UpdateEnergyCost();
        }
    }
}