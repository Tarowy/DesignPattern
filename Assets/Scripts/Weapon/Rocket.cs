using UnityEngine;

namespace Weapon
{
    public class Rocket: Weapon
    {
        protected override void SetEffectDisplayTime() => effectDisplayTime = 0.4f;

        protected override void PlayBulletEffect(Vector3 targetPosition) => BulletEffect(0.3f, targetPosition);

        protected override void PlayWeaponSound() =>  WeaponSound("RocketShot");
    }
}