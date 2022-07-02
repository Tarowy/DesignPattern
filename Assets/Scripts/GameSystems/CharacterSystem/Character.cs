using GameSystems.CharacterSystem.Attribute;
using UnityEngine;
using UnityEngine.AI;

namespace GameSystems.CharacterSystem
{
    public abstract class Character
    {
        protected CharacterAttr characterAttr;
        protected GameObject characterObject;
        protected AudioSource audioSource;
        protected NavMeshAgent navMeshAgent;
        protected Animation animation;
        protected Weapon.Weapon weapon;

        public Vector3 Position => characterObject ? characterObject.transform.position : Vector3.zero;

        public float WeaponRange => weapon.WeaponRange;

        public void PlayAnimation(string animName)
        {
            animation.CrossFade(animName);
        }

        public void SetPosition(Vector3 targetPosition) => navMeshAgent.destination = targetPosition;


        public void Attack(Character target)
        {
            weapon.Fire(target.Position);
        }
    }
}