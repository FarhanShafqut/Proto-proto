using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playerMovement : MonoBehaviour
{
    private bool move = false;
    private float horizonatalInput;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private audioScript audio;
    private bool Fire = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GameObject.FindWithTag("soundManager").GetComponent<audioScript>();
        StaticStats.gameOver = false;
        StaticStats.heart = 5;
        StaticStats.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticStats.gameOver == false)
        {
            HandleMovement();
        }
    }
    private void HandleMovement()
    {
        if (!move)
        {
            horizonatalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizonatalInput * speed * Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {
           if(Fire== true)
            {
         
                Fire = false;
                StartCoroutine(cylinderAttack());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyAi"))
        {
            audio.hurtSound();
            Debug.Log("workinghere");
            StaticStats.HeartDecrease();

        }

    }
    IEnumerator cylinderAttack()
{
     
    Fire = false;
        Instantiate(bullet, attackPoint.transform.position, Quaternion.Euler(90f, 0f, 0f));
        yield return new WaitForSeconds(0.02f);
    Fire = true;
}

}

