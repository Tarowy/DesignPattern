using UnityEngine;

namespace Weapon
{
    public class Gun: Weapon
    {
        protected override void SetEffectDisplayTime() => effectDisplayTime = 0.2f;

        protected override void PlayBulletEffect(Vector3 targetPosition) => BulletEffect(0.05f, targetPosition);

        protected override void PlayWeaponSound() => WeaponSound("GunShot");

        public Gun(int damage, float range, GameObject weaponPrefab) : base(damage, range, weaponPrefab)
        {
        }
    }
}