using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
;        AddScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float newScoreValue)
    {
        print("add score");
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "$" + score.ToString("F2");
    }
}
