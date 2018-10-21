using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D wallHitBox;
    private float speed;
   

    //ground check
    private bool wallHit;
    public Transform groundcheck;
    public float boxWidth;
    public float boxHeight;
    public LayerMask isGround;

    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff




    // Use this for initialization
    void Start()
    {
        wallHitBox = GetComponent<Rigidbody2D>();
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(boxWidth, boxHeight), 0, isGround);

        if (wallHit == true)
        {
            speed = speed * -1;
        }       
    }

   

}
