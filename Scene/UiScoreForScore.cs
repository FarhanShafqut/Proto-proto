using TMPro;
using UnityEngine;

public class UiScoreForScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text scoreText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = StaticStats.score.ToString("0");

    }
}
