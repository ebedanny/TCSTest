﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingObject : MonoBehaviour , IPointerDownHandler
{
    public Vector2 moveDir;
    public float speed;
    Vector3 leftTrans;
    Vector3 rightTrans;

    bool isRight = true;
    bool isLeft;

    bool canMove=true;
    void Start()
    {
        rightTrans.x = transform.position.x+5;
        rightTrans.y = transform.position.y;
        rightTrans.z = transform.position.z;
        leftTrans.x = transform.position.x-5;
        leftTrans.y = transform.position.y;
        leftTrans.z = transform.position.z;

    }

    
    void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, rightTrans) < 1f)
            {
                isRight = true;
                isLeft = false;
            }

            if (isRight)
            {
                transform.Translate(-moveDir * speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, leftTrans) < 1f)
            {
                isLeft = true;
                isRight = false;
            }

            if (isLeft)
            {
                transform.Translate(moveDir * speed * Time.deltaTime);
            }
        }

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("1");

        canMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            canMove = false;
        }
    }
}