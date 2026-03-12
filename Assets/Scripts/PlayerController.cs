using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigidbod2D;
    public float force = 0f;
    public float jumpForce = 0f;
    Vector2 movement;

    int coinAmout = 0;

    public AudioClip hyppy;
    public AudioClip hitSound;
    public AudioClip deathSound;

    public AudioSource playerAS;

    bool grounded;
    bool powerUpped = false;
    bool hittable = false;
    bool finished = false;

    GameController gameController;
    EnemyScript currentEnemy;

    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI clockUI;

    public TextMeshProUGUI finalTimeUI;

    public int coinMaxAmount;

    public int powerUpSpeedPlus;

    float time;
    float timerPowerUp = 60;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbod2D = GetComponent<Rigidbody2D>();
        playerAS = GetComponent<AudioSource>();
        gameController = FindFirstObjectByType<GameController>();
        coinMaxAmount = GameObject.FindGameObjectsWithTag("Coin").Length;

        coinUI.text = coinAmout.ToString() + " / " + coinMaxAmount;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timerPowerUp);
        if (powerUpped == true)
        {

            FormatTime(timerPowerUp) -= Time.deltaTime;

        }
        time += Time.deltaTime;
        clockUI.text = FormatTime(time).ToString();

        finalTimeUI.text = FormatTime(time).ToString();

        float horizontal = Input.GetAxisRaw("Horizontal");
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
            currentEnemy.TakeDamage(1);


        }
    }

    private string FormatTime(float time)
    {
        int mins = Mathf.FloorToInt(time / 60f);
        int secs = Mathf.FloorToInt(time % 60f);
        int ms = Mathf.FloorToInt((time * 1000f) % 1000f);
        return $"{mins:00}:{secs:00}.{ms:00}";



    }



    void Finish()
    {
        finished = true;
        gameController.winState();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyScript>() != null)
        {
            hittable = true;
            currentEnemy = collision.GetComponent<EnemyScript>();
        }

        if (collision.transform.tag == "Coin")
        {
            GetCoin(collision.gameObject);
        }

        if (collision.transform.tag == "PowerUp1")
        {
            GetPowerUp(collision.gameObject);
        }

        if (collision.transform.tag == "Finish")
        {
            Finish();
        }

        if (collision.transform.tag == "KillZ")
        {

            gameController.gameOver();



        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyScript>() != null)
        {
            hittable = false;
            currentEnemy = null;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * (force + powerUpSpeedPlus) * Time.deltaTime);


    }




    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("IsGrounded");
            grounded = true;


        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Debug.Log("NotGrounded");
            grounded = false;


        }
    }
    void GetCoin(GameObject _coin)
    {
        coinAmout++;
        coinUI.text = coinAmout.ToString() + " / " + coinMaxAmount;
        _coin.GetComponent<Coin>().MakeSound();


    }

    void GetPowerUp(GameObject _powerup)
    {
        //coinUI.text = coinAmout.ToString() + " / " + coinMaxAmount;
        _powerup.GetComponent<PowerUp>().MakeSound();

        if (powerUpped == true)
        {
            if (timerPowerUp <= 0)
            {
                powerUpSpeedPlus = 0;
                powerUpped = false;
            }
            else
            {
                powerUpSpeedPlus += 3;
            }
        }
    }
}
