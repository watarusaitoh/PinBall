using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score;
    public Text ScoreText;
    void SetCountText()
    {
        ScoreText.text = "Score:"+score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
        SetCountText(); 
    }
    // Update is called once per frame
    void Update()
    { 
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            score = score + 200;
            SetCountText();
        }
        if (other.gameObject.CompareTag( "LargeStarTag"))
        {
            score = score + 100;
            SetCountText();
        }
        if (other.gameObject.CompareTag ("SmallCloudTag"))
        {
            score = score + 50;
            SetCountText();
        }
        if (other.gameObject.CompareTag( "SmallStarTag"))
        {
            score = score + 20;
            SetCountText();
        }
        
    }
}