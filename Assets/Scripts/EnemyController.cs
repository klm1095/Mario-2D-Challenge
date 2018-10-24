using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public LayerMask isGround;
    public Transform wallHitBox;

    public AudioClip Death;
    private AudioSource source3;

    public float wallHitWidth;
    public float wallHitHeight;

    private bool wallHit;

    void Awake()
    {
        source3 = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if(wallHit == true)
        {
            speed = speed * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("I Loved Living");
            Destroy(gameObject, 0.25f);
            source3.PlayOneShot(Death, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
