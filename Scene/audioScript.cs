using UnityEngine;

public class audioScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    public AudioClip ballShattering;
    public AudioClip bullet;
    public AudioClip hurt;
    public AudioClip bulletCollison;
    public static audioScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        // Skip ahead 2 seconds into the clip
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 1f;
        audioSource.Play();
    }
    public void slimeShatter()
    {
        audioSource.PlayOneShot(ballShattering, 0.5f);
    }
    public void magicCircle()
    {
        audioSource.PlayOneShot(bullet, 0.5f);
    }
    public void hurtSound()
    {
        audioSource.PlayOneShot(hurt, 1f);
    }
    public void bulletSound()
    {
        audioSource.PlayOneShot(bulletCollison, 0.09f);
    }
}
