using UnityEngine;

public class SpreadGun : GunShootLimit
{
    public float spreadAngle = 10f;

    public override void Shoot()
    {
        for (int i = -1; i <= 1; i++)
        {
            var projectile = Instantiate(prefabProjectile);

            Quaternion spreadRotation =
                positionToShoot.rotation *
                Quaternion.Euler(0, i * spreadAngle, 0);

            projectile.transform.position = positionToShoot.position;
            projectile.transform.rotation = spreadRotation;
            projectile.speed = speed;
        }
    }
}
