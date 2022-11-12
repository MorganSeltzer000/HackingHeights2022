using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //public Player myPlayer;
    public TextMeshProUGUI LivesText;
    //int score;
    // Start is called before the first frame update
    void Start()
    {
        LivesText.text = Player.lives.ToString();
        //LivesText.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }
    /*
    public void AddScore(int amount)
    {
        score += amount;
    }*/

    public void LoseLife()
    {
        LivesText.text = "Requiescat In Pace";
    }

    public void ShowLives()
    {
        LivesText.text = Player.lives.ToString();
    }
    public void EndGame()
    {
        LivesText.text = "We're in the endgame now";
    }
    // Update is called once per frame
    void Update()
    {
    }
}