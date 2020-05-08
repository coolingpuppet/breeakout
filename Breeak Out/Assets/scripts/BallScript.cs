using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool inPlay;
    public Transform paddle;
    public Transform healthPowerUP;

    public float speed;
    public float luck;
    public Transform explosion;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameover)
        {
            return;
        }


        if (!inPlay)
        {
            transform.position = paddle.position;

        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other. CompareTag("bottom"))
        {
            Debug.Log ("Ball hit bottom");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives (-1);
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("bricks"))
        {
            int randChance = Random.Range(1, 101);
            if (randChance < luck)
            {
                Instantiate (healthPowerUP, other.transform.position, other.transform.rotation);
            }
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy (newExplosion.gameObject, 2.5f);

            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);
            gm.UpdateNumberofBricks();



            Destroy (other.gameObject);

        }

    }
}
