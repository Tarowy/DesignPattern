using GameSystems.CharacterSystem.Solider;
using Weapon;

namespace GameSystems.EnergySystem.EnergyStrategy
{
    public abstract class EnergyCostStrategy
    {
        public abstract int GetCampUpgradeCost(SoliderType soliderType, int level);
        public abstract int GetWeaponUpgradeCost(WeaponType weaponType);
        public abstract int GetSoliderTrainCost(SoliderType soliderType, int level);
    }
}