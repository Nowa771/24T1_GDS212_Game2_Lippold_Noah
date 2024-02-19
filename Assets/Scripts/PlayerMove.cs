using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody playerRigidbody;

    void Start()
    {
        // Get the Rigidbody component attached to the player
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply jump force to the player
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Set isGrounded to false to prevent multiple jumps in the air
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        // Apply gravity to the player using Rigidbody's gravity
        playerRigidbody.AddForce(Vector3.down * 9.8f, ForceMode.Acceleration);
    }
}
