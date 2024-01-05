using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPosition.x < 0)
            {
                _rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                _rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
