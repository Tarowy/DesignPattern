using Factory;
using GameSystems.CharacterSystem;
using UnityEngine;

namespace Weapon
{
    public enum WeaponType
    {
        Rocket,
        Rifle,
        Gun
    }
    /// <summary>
    /// 桥接（Bridge）是用于把抽象化与实现化解耦，使得二者可以独立变化。
    /// 这种类型的设计模式属于结构型模式，它通过提供抽象化和实现化之间的桥接结构，来实现二者的解耦。
    /// 这种模式涉及到一个作为桥接的接口，使得实体类的功能独立于接口实现类。这两种类型的类可被结构化改变而互不影响。
    /// https://www.runoob.com/design-pattern/bridge-pattern.html
    /// </summary>
    public abstract class Weapon
    {
        public int damage;
        protected float range;
        protected float criticalMulti;

        protected GameObject weaponPrefab;

        protected ParticleSystem particleSystem;
        protected LineRenderer lineRender;
        protected Light light;
        protected AudioSource audioSource;

        protected Character owner;
        protected float effectDisplayTime;

        public float WeaponRange => range;

        protected Weapon(int damage,float range,GameObject weaponPrefab)
        {
            this.damage = damage;
            this.range = range;
            this.weaponPrefab = weaponPrefab;

            var effect= weaponPrefab.transform.Find("Effect");
            particleSystem = effect.GetComponent<ParticleSystem>();
            lineRender = effect.GetComponent<LineRenderer>();
            light = effect.GetComponent<Light>();
            audioSource = effect.GetComponent<AudioSource>();
        }

        public Character Owner
        {
            set => owner = value;
        }

        public GameObject WeaponPrefab => weaponPrefab;
        
        public void Update()
        {
            if (effectDisplayTime > 0)
            {
                effectDisplayTime -= Time.deltaTime;
                if (effectDisplayTime <= 0)
                {
                    DisableEffect();
                }
            }
        }

        protected abstract void SetEffectDisplayTime();

        /*
         * 在模板模式（Template Pattern）中，一个抽象类公开定义了执行它的方法的方式/模板。
         * 它的子类可以按需要重写方法实现，但调用将以抽象类中定义的方式进行。
         * 这种类型的设计模式属于行为型模式。
         * https://www.runoob.com/design-pattern/template-pattern.html
         */
        public void Fire(Vector3 position)
        {
            PlayMuzzleEffect();
            PlayBulletEffect(position);
            SetEffectDisplayTime();
            PlayWeaponSound();
        }

        /// <summary>
        /// 枪口特效
        /// </summary>
        protected virtual void PlayMuzzleEffect()
        {
            particleSystem.Stop();
            particleSystem.Play();
            light.enabled = true;
        }

        protected abstract void PlayBulletEffect(Vector3 targetPosition);

        /// <summary>
        /// 子弹特效
        /// </summary>
        protected virtual void BulletEffect(float width, Vector3 targetPosition)
        {
            lineRender.enabled = true;
            lineRender.startWidth = lineRender.endWidth = width;
            //设置lineRender顶点的位置
            lineRender.SetPosition(0, weaponPrefab.transform.position);
            lineRender.SetPosition(1, targetPosition);
        }

        protected abstract void PlayWeaponSound();

        /// <summary>
        /// 武器声音
        /// </summary>
        protected virtual void WeaponSound(string clipName)
        {
            var audioClip = FactoryManager.AssetFactory.LoadAudioClip(clipName);
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        protected void DisableEffect()
        {
            lineRender.enabled = false;
            light.enabled = false;
        }
    }
}