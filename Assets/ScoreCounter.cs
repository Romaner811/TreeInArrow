using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    public Text TextObject;

    private bool shouldUpdate;

    public void AddScore(int points)
    {
        this.Score += points;
        this.shouldUpdate = true;
    }

    void Start()
    {
        this.shouldUpdate = true;
    }

    void Update()
    {
        if (this.shouldUpdate)
        {
            this.TextObject.text = this.Score.ToString();
            this.shouldUpdate = false;
        }
    }
}
