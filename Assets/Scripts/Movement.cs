using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private KeyCode JumpButton = KeyCode.Space;
    [SerializeField] private Collider2D feetCollider;
    [SerializeField] private string groundLayer = "Ground";

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerSR;
    private bool isGrounded;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
        Flip(playerInput);
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask(groundLayer));
        if (Input.GetKeyDown(JumpButton)&& isGrounded)
        {
            Jump();
        }
    }

    private void Move(float direction)
    {
        playerAnimator.SetBool("Run", direction != 0);
        playerRigidbody.velocity = new Vector2(direction * speed, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(playerRigidbody.velocity.x, JumpForce);
        playerRigidbody.velocity += jumpVector;
    }

    private void Flip(float direction)
    {
        if (direction > 0)
        {
            playerSR.flipX = false;
        }
        if (direction < 0)
        {
            playerSR.flipX = true;
        }
    }

}
