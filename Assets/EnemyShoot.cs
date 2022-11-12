using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootDirectionBehaviour { Static, TowardsPlayer };

public class EnemyShoot : MonoBehaviour
{
    public ShootDirectionBehaviour shootingDirection;

    public void Shoot()
    {
        if (shootingDirection == ShootDirectionBehaviour.Static)
        {

        }
        else if (shootingDirection == ShootDirectionBehaviour.TowardsPlayer)
        {

        }
    }
}
