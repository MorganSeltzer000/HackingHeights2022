using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Projectile PlayerBullet;
    public Scoreboard theScoreboard;
    // Start is called before the first frame update
    void Start()
    {
    }

    public static int lives = 3;
    float fireCooldown = 0.25f;
    float timeUntilReload = 0;
    float bulletSpeed = 7f;
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
            myBullet.SetTravel(Vector2.up, bulletSpeed + y*playerSpeed/2);
            timeUntilReload = Time.time + fireCooldown;
        }
    }

    float SpriteWidth = 0.45f;
    float SpriteHeight = 0.57f;
    float playerSpeed = 4;
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - SpriteWidth/2;
        min.x = min.x + SpriteWidth / 2;
        max.y = max.y - SpriteHeight / 2;
        min.y = min.y + SpriteHeight / 2;
        Vector2 pos = transform.position;
        pos += direction * playerSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    public LayerMask enemyLayerMask;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ExtraLayers.LayerInLayerMask(collision.gameObject.layer, enemyLayerMask))
        {
            Die();
        }
        /*if((collision.CompareTag("Enemy")) ||  (collision.CompareTag("Bullit")))
        {
            
        }*/
    }
    
    void Die()
    {
        if (lives < 1)
        {
            GameOver();
            return;
        }
        lives--;
        theScoreboard.LoseLife();
        //todo, implement waiting
        Debug.Log("Hi there");
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Hey there");
        theScoreboard.ShowLives();
        return;
    }
    void GameOver()
    {
        theScoreboard.EndGame();
    }
}