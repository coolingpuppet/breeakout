using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float RightScreenEdge;
    public float LeftScreenEdge;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameover)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < LeftScreenEdge)
        {
            transform.position = new Vector2(LeftScreenEdge,transform.position.y);
        }
        if (transform.position.x > RightScreenEdge)
        {
            transform.position = new Vector2(RightScreenEdge,transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("ExtraLives"))
        {
            gm.UpdateLives (1);
            Destroy (other.gameObject);
        
        }

    }
}
