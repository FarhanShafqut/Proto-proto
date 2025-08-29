using System.Collections;
using UnityEngine;

public class clock : MonoBehaviour
{
    public bool stop = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("floor"))
        {
            StartCoroutine(heartDes());
            //transform.translate(0f, 0f, 0f);
        }
        if (collision.collider.CompareTag("Player"))
        {
            stop = true;
            //StaticStats.ScoreIncrease();
            Destroy(gameObject);
            
        }
    }
    IEnumerator heartDes()
    {
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }

}
