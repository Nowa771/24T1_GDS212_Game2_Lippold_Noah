using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
