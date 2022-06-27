using GameSystems.CharacterSystem;
using UnityEngine;

namespace Weapon
{
    /// <summary>
    /// 桥接（Bridge）是用于把抽象化与实现化解耦，使得二者可以独立变化。
    /// 这种类型的设计模式属于结构型模式，它通过提供抽象化和实现化之间的桥接结构，来实现二者的解耦。
    /// 这种模式涉及到一个作为桥接的接口，使得实体类的功能独立于接口实现类。这两种类型的类可被结构化改变而互不影响。
    /// https://www.runoob.com/design-pattern/bridge-pattern.html
    /// </summary>
    public abstract class Weapon
    {
        protected int damage;
        protected float range;
        protected float criticalMulti;

        protected GameObject gameObject;
        protected Character owner;
        
        protected ParticleSystem particleSystem;
        protected LineRenderer lineRender;
        protected Light light;
        protected AudioSource audioSource;

        public abstract void Fire(Vector3 position);
    }
}