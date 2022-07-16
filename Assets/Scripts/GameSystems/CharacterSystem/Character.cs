using System.Collections.Generic;
using Factory;
using GameSystems.CharacterSystem.Attribute;
using MonoBe;
using Tools;
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

        public CharacterAttr CharacterAttr
        {
            set => characterAttr = value;
            get => characterAttr;
        }

        public GameObject CharacterObject
        {
            set
            {
                characterObject = value;
                audioSource = characterObject.GetComponent<AudioSource>();
                navMeshAgent = characterObject.GetComponent<NavMeshAgent>();
                animation = characterObject.GetComponentInChildren<Animation>();
            }
        }

        public Weapon.Weapon Weapon
        {
            set
            {
                weapon = value;
                weapon.Owner = this;
                //需要将加载的资源实例化才能设置父子关系
                UnityTools.Attach(UnityTools.FindChild(characterObject, "weapon-point"), weapon.WeaponPrefab);
            }
        }

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
            target.GetDamage(weapon.WeaponBaseAttr.Damage + characterAttr.CriticalValue);
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
            var effectResource=FactoryManager.AssetFactory.LoadEffect(effectName);
            effectResource.transform.position = Position;
            effectResource.AddComponent<DestroyEffect>();
        }

        public virtual void Sound(string soundName)
        {
            var clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}