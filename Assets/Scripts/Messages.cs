using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Messages : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI MessageText;
    void Start()
    {
        DisplayMessage(StartMessage);
        NextMessage();
        DisplayMessage(StartMessage2);
    }

    string StartMessage = "You and your crewmates have encountered strange creatures. Survive!";
    string StartMessage2 = "Also, you shoot by pressing space, fun fact.";
    Queue<string> MessageQueue = new Queue<string>();
    void DisplayMessage(string message)
    {
        MessageQueue.Enqueue(message);
    }

    void NextMessage()
    {
        if (MessageQueue.Count < 1) {
            MessageText.text = "";
            return;
        }
        MessageText.text = MessageQueue.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        //todo verify that I need both, and works for both
        if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
        {
            NextMessage();
        }
    }
}