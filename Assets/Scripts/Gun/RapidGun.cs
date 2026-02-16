public class RapidGun : GunShootLimit
{
    protected override void Awake()
    {
        base.Awake();

        timeBetweenShoot = 0.05f;
        maxShoot = 5;
        timeToRecharge = 3f;
    }
}
