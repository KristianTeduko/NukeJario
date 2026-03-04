using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigidbod2D;
    public float force = 0f;

    public float jumpForce = 0f;
    Vector2 movement;
    bool grounded;

    public AudioClip hyppy;
    public AudioClip hitSound;
    public AudioClip deathSound;

    public AudioSource playerAS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbod2D = GetComponent<Rigidbody2D>();
        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, 0).normalized;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("JUMP");
            playerAS.PlayOneShot(hyppy);
            PlayerRigidbod2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;

        }

        if (Input.GetButtonDown("Fire1") && hittable)
        {

            Debug.Log("HIT");
            playerAS.PlayOneShot(hitSound);



        }
    }




    private void FixedUpdate()
    {
        transform.Translate(movement * force * Time.deltaTime);


    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("IsGrounded");
            grounded = true;


        }
    }











    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Ground")
    //    {
    //        Debug.Log("NotGrounded");
    //        grounded = false;


    //    }
    //}
}
