using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(0))
            return;

        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (clickPos.x <= 0)
        {
            transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        }
    }
}
