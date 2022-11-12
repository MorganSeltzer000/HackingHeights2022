using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public LayerMask TargetLayerMask;


    [Flags]
    public enum TriggerAndCollisionMask
    {
        IgnoreAll = 0,
        OnTriggerEnter = 1 << 0,
        OnTriggerStay = 1 << 1,
        OnTriggerEnter2D = 1 << 6,
        OnTriggerStay2D = 1 << 7,

        All_3D = OnTriggerEnter | OnTriggerStay,
        All_2D = OnTriggerEnter2D | OnTriggerStay2D,
        All = All_3D | All_2D
    }

    protected const TriggerAndCollisionMask AllowedTriggerCallbacks = TriggerAndCollisionMask.OnTriggerEnter
                                                                  | TriggerAndCollisionMask.OnTriggerStay
                                                                  | TriggerAndCollisionMask.OnTriggerEnter2D
                                                                  | TriggerAndCollisionMask.OnTriggerStay2D;

    /// Defines on what triggers the damage should be applied, by default on enter and stay (both 2D and 3D) but this field will let you exclude triggers if needed
    [Tooltip(
        "Defines on what triggers the damage should be applied, by default on enter and stay (both 2D and 3D) but this field will let you exclude triggers if needed")]
    public TriggerAndCollisionMask TriggerFilter = AllowedTriggerCallbacks;

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

    #region CollisionDetection

    /// <summary>
    /// When a collision with the player is triggered, we give damage to the player and knock it back
    /// </summary>
    /// <param name="collider">what's colliding with the object.</param>
    public virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (0 == (TriggerFilter & TriggerAndCollisionMask.OnTriggerStay2D)) return;
        Colliding(collider.gameObject);
    }

    /// <summary>
    /// On trigger enter 2D, we call our colliding endpoint
    /// </summary>
    /// <param name="collider"></param>S
    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (0 == (TriggerFilter & TriggerAndCollisionMask.OnTriggerEnter2D)) return;
        Colliding(collider.gameObject);
    }

    /// <summary>
    /// On trigger stay, we call our colliding endpoint
    /// </summary>
    /// <param name="collider"></param>
    public virtual void OnTriggerStay(Collider collider)
    {
        if (0 == (TriggerFilter & TriggerAndCollisionMask.OnTriggerStay)) return;
        Colliding(collider.gameObject);
    }

    /// <summary>
    /// On trigger enter, we call our colliding endpoint
    /// </summary>
    /// <param name="collider"></param>
    public virtual void OnTriggerEnter(Collider collider)
    {
        if (0 == (TriggerFilter & TriggerAndCollisionMask.OnTriggerEnter)) return;
        Colliding(collider.gameObject);
    }

    #endregion

    protected virtual bool EvaluateAvailability(GameObject collider)
    {
        // if we're inactive, we do nothing
        if (!isActiveAndEnabled) { return false; }

        // if what we're colliding with isn't part of the target layers, we do nothing and exit
        if (!ExtraLayers.LayerInLayerMask(collider.layer, TargetLayerMask)) { return false; }

        // if we're on our first frame, we don't apply damage
        if (Time.time == 0f) { return false; }

        return true;
    }

    #region OnCollision

    /// <summary>
    /// When colliding, we apply the appropriate damage
    /// </summary>
    /// <param name="collider"></param>
    protected virtual void Colliding(GameObject collider)
    {
        if (!EvaluateAvailability(collider))
        {
            return;
        }

        OnProjectileFinish(0);
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

    #endregion
}
