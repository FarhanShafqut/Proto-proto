using System.Collections;
using UnityEngine;

public class spwanEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject slime;
    public float random;
    public bool spwan = false;
    [SerializeField] public GameObject heart;
    public bool heartlife = false;
    public int randomHeart;
    void Start()
    {
        //this.enabled = true;
        randomHeart = Random.Range(7, 15);
        InvokeRepeating("SlimeSpwan", 2f, 8.5f);
        InvokeRepeating("heartSpwan", 2f, randomHeart);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SlimeSpwan()
    {
        if (StaticStats.gameOver)
        {
            this.enabled = false;
        }
        spwan = true;
        random = Random.Range(-15f, 15f);
        Vector3 newpos = new Vector3(random, 8.71f, 0f);
        Instantiate(slime, newpos, transform.rotation);
        spwan = false;

    }
    private void heartSpwan()
    {
        randomHeart = Random.Range(3, 7);
        heartlife = true;
        random = Random.Range(-13f, 14.5f);
        Vector3 newpos = new Vector3(random, 11.25f, 0f);
        Instantiate(heart, newpos, transform.rotation);
        heartlife = false;
    }
}
