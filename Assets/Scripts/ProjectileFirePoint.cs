using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootDirectionBehaviour { Static, TowardsPlayer };

public class ProjectileFirePoint : MonoBehaviour
{
    public ShootDirectionBehaviour shootingDirection;

    [HideInInspector]
    public Transform FirePoint;
    public Projectile projectilePrefab;

    public float timeBetweenFiring;
    float firingTimer;

    private void Update()
    {
        CountDownFiringTimer();
    }

    void CountDownFiringTimer()
    {
        firingTimer -= Time.deltaTime;
        if (firingTimer <= 0)
        {
            Shoot();
            firingTimer += timeBetweenFiring;
        }
    }

    public virtual void Shoot()
    {
        if (shootingDirection == ShootDirectionBehaviour.Static)
        {
            Projectile projectile = Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
            projectile.SetTravel(RotationToVector(FirePoint.rotation.eulerAngles.z));
        }
        else if (shootingDirection == ShootDirectionBehaviour.TowardsPlayer)
        {

        }
    }

    Vector2 RotationToVector(float degrees)
    {

        Quaternion rotation = Quaternion.Euler(0, 0, degrees);
        Vector2 v = rotation * Vector3.down;

        return v;
    }
}
