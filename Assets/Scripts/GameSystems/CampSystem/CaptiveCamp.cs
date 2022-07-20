using GameSystems.CampSystem.Command;
using GameSystems.CharacterSystem.Enemy;
using GameSystems.CharacterSystem.Solider;
using GameSystems.EnergySystem.EnergyStrategy;
using UnityEngine;
using Weapon;

namespace GameSystems.CampSystem
{
    /// <summary>
    /// 俘兵兵营
    /// </summary>
    public class CaptiveCamp : Camp
    {
        public CaptiveCamp(string campName, string campSprite,
            GameObject prefab, EnemyType enemyType,
            Vector3 musterPosition, float trainTime)
            : base(campName, campSprite, prefab, SoliderType.Captive, musterPosition, trainTime)
        {
            this.EnemyType = enemyType;
            energyCostStrategy = new SoliderCostStrategy();
            UpdateEnergyCost();
        }

        public EnemyType EnemyType { private set; get; }
        public override int Level => 1; //俘虏固定1级
        public override WeaponType WeaponType { get; } = WeaponType.Gun;
        public override int CampUpgradeCost => 0; //俘兵营无法升级
        public override int WeaponUpgradeCost => 0; //俘兵武器无法升级
        public override int TrainCost { set; get; }

        public override void Train()
        {
            Debug.Log("俘兵训练");
            commands.Enqueue(new TrainCaptiveCommand(EnemyType,WeaponType,musterPosition));
        }

        public override void UpdateEnergyCost()
        {
            TrainCost = energyCostStrategy.GetSoliderTrainCost(SoliderType.Captive, 1);
        }

        public override void UpgradeCamp()
        {
        }

        public override void UpgradeWeapon()
        {
        }
    }
}