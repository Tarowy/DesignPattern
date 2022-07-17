using System;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;

namespace GameSystems.EnergySystem
{
    public class EnergySystem : IGameSystem
    {
        private const float MaxEnergy = 100f;
        private float _currentEnergy = MaxEnergy;
        private float _recoverSpeed = 3;

        public void Init()
        {
           
        }

        public void Update()
        {
            GameFacade.Instance.UpdateEnergySlider(_currentEnergy, MaxEnergy);
            if (_currentEnergy >= MaxEnergy)
            {
                return;
            }

            _currentEnergy = Math.Min(_currentEnergy + _recoverSpeed * Time.deltaTime, MaxEnergy);
        }

        public void Release()
        {
        }


        public bool CostEnergy(float value)
        {
            if (value > _currentEnergy)
            {
                return false;
            }

            _currentEnergy -= value;
            return true;
        }

        public void RecycleEnergy(float value)
        {
            _currentEnergy = Math.Min(_currentEnergy + value, MaxEnergy);
        }
    }
}