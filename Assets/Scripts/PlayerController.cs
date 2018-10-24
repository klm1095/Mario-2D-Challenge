using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;

    public AudioClip jump;
    public AudioClip coin;


    private AudioSource source;
    private AudioSource source2;
    

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private int count;
    public Text countText;




    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetCountText();      
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
     

    void Awake()
    {

        // source = GetComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
        
        
    }


    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);



        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            source2.PlayOneShot(coin, 1f);
            count = count + 1;
            SetCountText();
        }

        else if(other.gameObject.CompareTag ("Box"))
        {
            count = count + 1;
            SetCountText();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.Space))
            {
                //rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;


                // Audio stuff
                source.PlayOneShot(jump, 1f);



            }
        }
    }

  
}
