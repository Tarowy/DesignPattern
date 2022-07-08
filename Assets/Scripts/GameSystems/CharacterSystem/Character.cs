using System.Collections.Generic;
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

        public abstract void UpdateFsmAI(List<Character> characters);

        public void PlayAnimation(string animName)
        {
            animation.CrossFade(animName);
        }

        public void SetPosition(Vector3 targetPosition)
        {
            navMeshAgent.destination = targetPosition;
            PlayAnimation("Move");
        }


        public void Attack(Character target)
        {
            characterObject.transform.LookAt(target.Position);
            weapon.Fire(target.Position);
            PlayAnimation("Attack");
            target.GetDamage(weapon.damage + characterAttr.CriticalValue);
        }

        public virtual void GetDamage(int damage)
        {
            characterAttr.GetDamage(damage);
            //被攻击的特效(只有敌人有)
            
            
            //死亡的特效、音效(只有战士有)

        }

        public void Dead()
        {
            
        }

        public void Update()
        {
            weapon.Update();
        }
        
        public virtual void Effect(string effectName)
        {
            GameObject effectResource;
        }

        public virtual void Sound(string soundName)
        {
            AudioClip clip = null;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}