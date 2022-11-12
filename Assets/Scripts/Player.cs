using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Projectile PlayerBullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    float fireCooldown = 0.2f;
    float timeUntilReload = 0;
    float bulletSpeed = 4f;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);

        if(Input.GetKey("space") & Time.time > timeUntilReload)
        {
            Projectile myBullet = Instantiate(PlayerBullet, this.transform.position, this.transform.rotation);
            myBullet.SetTravel(Vector2.up, bulletSpeed);
            timeUntilReload = Time.time + fireCooldown;
        }
    }

    float SpriteWidth = 0.45f;
    float SpriteHeight = 0.57f;
    float speed = 4;
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - SpriteWidth/2;
        min.x = min.x + SpriteWidth / 2;
        max.y = max.y - SpriteHeight / 2;
        min.y = min.y + SpriteHeight / 2;
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    public LayerMask enemyLayerMask;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ExtraLayers.LayerInLayerMask(collision.gameObject.layer, enemyLayerMask))
        {
            Die();
        }
        /*if((collision.CompareTag("Enemy")) ||  (collision.CompareTag("Bullit")))
        {
            
        }*/
    }

    public int lives = 3;
    void Die()
    {
        if (lives < 0)
        {
            GameOver();
            return;
        }
        lives--;
        //send some message
        return;
    }
    void GameOver()
    {
        //stuff
    }
}