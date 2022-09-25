using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
    }

    private void Move(float direction)
    {
        playerRigidbody.velocity = new Vector2(direction * speed, playerRigidbody.velocity.y);
    }
    
}
