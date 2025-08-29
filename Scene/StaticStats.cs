using UnityEngine;

public class StaticStats : MonoBehaviour
{
    public static int heart = 5;
    public static int score = 0;
    public static bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void HeartDecrease()
    {
        if (heart == 0)
        {
            gameOver = true;
        }
        else
        {
            heart--;
        }
    }

    public static void ScoreIncrease()
    {
        score++;
    }
    public static void HeartIncrease()
    {
        heart++;
    }
}
