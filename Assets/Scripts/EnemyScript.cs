using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioClip enemyDeathSound;
    public AudioSource enemyAS;
    int health = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int _damage)
    {


        health -= _damage;
        CheckDeath();

    }


    void CheckDeath()
    {
        if (health <= 0)
        {
            //kuolema
            enemyAS.PlayOneShot(enemyDeathSound);
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 2);



        }




    }


}
