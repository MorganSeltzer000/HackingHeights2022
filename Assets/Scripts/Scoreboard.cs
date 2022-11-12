using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Player myPlayer;
    public TextMeshProUGUI LivesText;
    // Start is called before the first frame update

    void Start()
    {
        LivesText.text = myPlayer.lives.ToString();
        //LivesText.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
