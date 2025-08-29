using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UiScores : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text heartText;

    void Start()
    {
        heartText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        heartText.text = StaticStats.heart.ToString("0");

    }
}
