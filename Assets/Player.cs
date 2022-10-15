using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    
    private bool jumpPressed;
    private float horizontalInput;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(horizontalInput, rigidBody.velocity.y, 0);
        
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        
        if (jumpPressed)
        {
            rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpPressed = false;
        }
    }
}
