using System.Collections;
using UnityEngine;

public class bulletsAi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 20f;
    private bool attack = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!attack)
        {
            StartCoroutine(Attack());
        }
        if (transform.position.y > 14)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Attack()
    {
        attack = true;
        rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        yield return new WaitForSeconds(0.4f);
        attack = false;
    }

}
