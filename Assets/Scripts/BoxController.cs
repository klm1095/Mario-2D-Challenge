using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public Transform wallHitBox;

    public AudioClip coin;
    private AudioSource source3;
    public LayerMask isGround;

    public float wallHitWidth;
    public float wallHitHeight;

    private bool wallHit;

    void Awake()
    {
        source3 = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            if (collision.collider.tag == "Player")
            {
                Debug.Log("I Loved Living");
                Destroy(gameObject, 0.25f);
                source3.PlayOneShot(coin, 3f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
