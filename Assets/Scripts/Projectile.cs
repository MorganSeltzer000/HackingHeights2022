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
    [Tooltip("Speed of this projectile")]
    public float speed;
    [HideInInspector]
    public Vector2 travelDirection;

    void Awake()
    {
        projectileCollider = GetComponent<Collider2D>();
    }

    public void SetTravel(Vector2 direction, float speed)
    {
        travelDirection = direction;
        this.speed = speed;
        rb.velocity = travelDirection * speed;
    }

    public void SetTravel(Vector2 direction)
    {
        travelDirection = direction;
        rb.velocity = travelDirection * speed;
    }

    public void SetTravel(float speed)
    {
        this.speed = speed;
        rb.velocity = travelDirection * speed;
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
        SetTravel(new Vector2(0, 0));
        projectileCollider.enabled = false;
        Destroy(this.gameObject, time);
    }
}
