using System;
using GameSystems.CharacterSystem.Solider;
using UnityEngine;
using Weapon;

namespace GameSystems.EnergySystem.EnergyStrategy
{
    public class SoliderCostStrategy: EnergyCostStrategy
    {
        public override int GetCampUpgradeCost(SoliderType soliderType, int level)
        {
            var energy = 0;
            switch (soliderType)
            {
                case SoliderType.Rookie:
                    energy = 60;
                    break;
                case SoliderType.Sergeant:
                    energy = 65;
                    break;
                case SoliderType.Captain:
                    energy = 70;
                    break;
                default:
                    Debug.LogError($"无法获取{soliderType}类型所需的升级费用");
                    break;
            }

            energy += (level - 1) * 2; //根据等级所需的额外耗费
            return Math.Min(energy, 100);
        }

        public override int GetWeaponUpgradeCost(WeaponType weaponType)
        {
            var energy = 0;
            //另外的武器已经是最高级了，不需要再升级
            switch (weaponType)
            {
                case WeaponType.Gun:
                    energy = 30;
                    break;
                case WeaponType.Rifle:
                    energy = 40;
                    break;
            }

            return energy;
        }

        public override int GetSoliderTrainCost(SoliderType soliderType, int level)
        {
            var energy = 0;
            switch (soliderType)
            {
                case SoliderType.Rookie:
                    energy = 10;
                    break;
                case SoliderType.Sergeant:
                    energy = 15;
                    break;
                case SoliderType.Captain:
                    energy = 20;
                    break;
                //俘虏固定十点能量消耗
                case SoliderType.Captive:
                    return 10;
                default:
                    Debug.LogError($"无法获取{soliderType}类型所需的升级费用");
                    break;
            }

            energy += (level - 1) * 2; //根据等级所需的额外耗费
            return energy;
        }
    }
}