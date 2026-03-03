using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigidbod2D;
    public float force = 0f;

    Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidbod2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

         movement = new Vector2(horizontal, 0).normalized;
    }




    private void FixedUpdate()
    {
        PlayerRigidbod2D.AddForce( * force);


    }

}
