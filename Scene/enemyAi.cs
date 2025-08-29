using System.Collections;
using TMPro;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    public int health;
    public GameObject ballPrefab;
    public GameObject coinPrefab;

    private Rigidbody rb;
    private int splitValue;
    private bool isDead = false;
    private int EnemeyDirection;
    public Renderer rend;
    private Vector3 velocity;
    public TextMeshPro numberText;
    [SerializeField] private audioScript audio;

    void Start()
    {
        audio = GameObject.FindWithTag("soundManager").GetComponent<audioScript>();
        if (rend == null)
            rend = GetComponentInChildren<Renderer>();
        rb = GetComponent<Rigidbody>();

        EnemeyDirection = Random.Range(1, 3);
        if (health <= 0)
        {
            health = Random.Range(20, 101);
        }

        splitValue = health;

        float scale = Mathf.Clamp(health / 20f, 1f, 4f);
        transform.localScale = new Vector3(scale, scale, scale);

        UpdateColor();


        if (numberText == null)
            numberText = GetComponentInChildren<TextMeshPro>();

        if (numberText != null)
        {
            numberText.text = health.ToString();
        }
    }
    private void FixedUpdate()
    {
        velocity = rb.linearVelocity;


    }
    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (other.CompareTag("playerBeam"))
        {
            audio.bulletSound();
            health -= 1;
            Debug.Log("Ball HP: " + health);
            StaticStats.ScoreIncrease();
            UpdateColor();

            if (numberText != null)
                numberText.text = health.ToString();

            Destroy(other.gameObject);

            if (health <= 0)
            {
                isDead = true;
                SplitBall();
            }
        }
    }



    void SplitBall()
    {

        if (coinPrefab != null)
        {

            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        int childHealth = splitValue / 2;

        // only split if childHealth big enough
        if (childHealth >= 10 && ballPrefab != null)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 offset = new Vector3(i == 0 ? -0.3f : 0.3f, 0.2f, 0f);
                GameObject newBall = Instantiate(ballPrefab, transform.position + offset, Quaternion.identity);

                enemyAi ai = newBall.GetComponent<enemyAi>();
                if (ai != null)
                {
                    ai.health = childHealth;
                    ai.splitValue = childHealth;
                }

                float childScale = Mathf.Clamp(childHealth / 20f, 1f, 4f);
                newBall.transform.localScale = Vector3.one * childScale;

                Renderer childRend = newBall.GetComponentInChildren<Renderer>();
                if (childRend != null)
                {
                    childRend.material.color = ColorForHealth(childHealth, childHealth);
                }

                TextMesh childText = newBall.GetComponentInChildren<TextMesh>();
                if (childText != null)
                {
                    childText.text = childHealth.ToString();
                    childText.transform.localScale = Vector3.one * (0.02f * (1f / newBall.transform.localScale.x));
                }

                Rigidbody rbNew = newBall.GetComponent<Rigidbody>();
                if (rbNew != null)
                {
                    rbNew.AddForce((i == 0 ? Vector3.left : Vector3.right) * 2f, ForceMode.VelocityChange);
                    rbNew.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
                }
            }
        }
        audio.slimeShatter();
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("floor"))
        {
            if (EnemeyDirection == 1)
            {
                rb.AddForce(Vector3.left * 70f * Time.deltaTime, ForceMode.VelocityChange);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * 16f, ForceMode.VelocityChange);
            }
            else if (EnemeyDirection == 2)
            {
                rb.AddForce(Vector3.right * 70f * Time.deltaTime, ForceMode.VelocityChange);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * 16f, ForceMode.VelocityChange);
            }
        }

        if (collision.collider.CompareTag("wallLeft"))
        {
            EnemeyDirection = 2;
            rb.AddForce(Vector3.up * 150f * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (collision.collider.CompareTag("wallRight"))
        {
            EnemeyDirection = 1;
            rb.AddForce(Vector3.up * 150f * Time.deltaTime, ForceMode.VelocityChange);
        }


    }

    void UpdateColor()
    {
        if (rend == null) return;

        int baseValue = Mathf.Max(1, splitValue); 
        float t = 1f - (float)health / baseValue;  

        Color col = Color.Lerp(Color.green, Color.red, t);

        rend.material.color = col;
    }

    Color ColorForHealth(int curHealth, int curSplitValue)
    {
        int baseValue = Mathf.Max(1, curSplitValue);
        float t = 1f - (float)curHealth / baseValue;
        return Color.Lerp(Color.green, Color.red, t);
    }
}
