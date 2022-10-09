using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private KeyCode JumpButton = KeyCode.Space;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private bool SpriteFlip;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
        Flip(playerInput);
        if (Input.GetKeyDown(JumpButton))
        {
            Jump();
        }
    }

    private void Move(float direction)
    {
        if (direction !=0)
        {
            playerAnimator.SetBool("Run", true);
        }
        else
        {
            playerAnimator.SetBool("Run", false);
        }
        playerRigidbody.velocity = new Vector2(direction * speed, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(playerRigidbody.velocity.x, JumpForce);
        playerRigidbody.velocity += jumpVector;
    }

    private void Flip(float direction)
    {
        
    }

}
