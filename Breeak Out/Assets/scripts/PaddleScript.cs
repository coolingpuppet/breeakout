﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float RightScreenEdge;
    public float LeftScreenEdge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
