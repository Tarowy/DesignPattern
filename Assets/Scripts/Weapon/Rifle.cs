using UnityEngine;

namespace Weapon
{
    public class Rifle: Weapon
    {
        protected override void SetEffectDisplayTime() => effectDisplayTime = 0.3f;

        protected override void PlayBulletEffect(Vector3 targetPosition) => BulletEffect(0.1f, targetPosition);

        protected override void PlayWeaponSound() => WeaponSound("RifleShot");

        public Rifle(int damage, float range, GameObject weaponPrefab) : base(damage, range, weaponPrefab)
        {
            
        }
    }
}