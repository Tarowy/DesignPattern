using System;
using GameSystems.CampSystem;
using Pattern.FacadeAndSingletonPattern;
using UnityEngine;

namespace MonoBe
{
    public class CampClick: MonoBehaviour
    {
        private Camp _camp;

        public Camp Camp
        {
            set => _camp = value;
        }
        
        public void OnMouseUpAsButton()
        {
            GameFacade.Instance.ShowCampInfo(_camp);
        }
    }
}