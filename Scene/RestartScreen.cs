using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScreen : MonoBehaviour
{
    [SerializeField] private GameObject restartScreen;
    private int num = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        restartScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticStats.gameOver == true && num == 1)
        {
            StartCoroutine(RestartDelay());
        }
    }
    public void onRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartScreen.SetActive(false);
    }
    public void onExit()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator RestartDelay()
    {
        num++;
        yield return new WaitForSeconds(3f);
        restartScreen.SetActive(true);
    }
}
