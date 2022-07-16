using UnityEngine;

namespace GameSystems
{
    public abstract class UserInterface
    {
        protected GameObject rootUI;
        
        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void Show() => rootUI.SetActive(true);
        public virtual void Hide() => rootUI.SetActive(false);
    }
}