using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxJumpForce = 20f;
    public float jumpTime = 2f;
    public float highJumpForceMultiplier = 2f; 

    private bool isGrounded;
    private Rigidbody playerRigidbody;
    private bool isJumping = false;
    private float jumpTimeCounter;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(1) && isGrounded)
        {
            HighJump();
        }
    }

    void Jump()
    {
       
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isGrounded = false;
    }

    void HighJump()
    {
        
        playerRigidbody.AddForce(Vector3.up * jumpForce * highJumpForceMultiplier, ForceMode.Impulse);

        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}