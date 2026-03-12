using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioClip PowerUpClip;
    AudioSource PowerUpAS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PowerUpAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeSound()
    {

        PowerUpAS.PlayOneShot(PowerUpClip);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 2);


    }


}
