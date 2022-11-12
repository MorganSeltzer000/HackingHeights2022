using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    [HideInInspector]
    private Collider2D projectileCollider;

    [Tooltip("Life time till projectile dissipates")]
    public float lifeTime;

    void Awake()
    {
        projectileCollider = GetComponent<Collider2D>();
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    void Update()
    {
        CountDownLife();
    }

    // Bullet lifetime decay, calls Destroy if lifetime reaches zero
    void CountDownLife()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            OnProjectileFinish(0);
        }
    }

    /// <summary>
    /// What heppens when the projectile reaches its end of life, and is about to be destroyed
    /// </summary>
    /// <param name="time"></param>
    public virtual void OnProjectileFinish(float time)
    {
        SetVelocity(new Vector2(0, 0));
        projectileCollider.enabled = false;
        Destroy(this.gameObject, time);
    }
}
