using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping = false;
    private bool isGrounded = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    //! audio
    public AudioSource audioSource;
    public AudioClip jumpSound;

    private Vector2 velocity = Vector2.zero;
    private float horizontalInput;

    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DeleteAllTrampolines();
        }

        Flip(rb.linearVelocity.x);

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("StateY", rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        Move(horizontalInput * moveSpeed);
    }

    void Move(float _horizontalMovement)
    {
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            audioSource.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
            spriteRenderer.flipX = false;
        else if (_velocity < -0.1f)
            spriteRenderer.flipX = true;
    }

    public void DeleteAllTrampolines()
    {
        GameObject[] trampolines = GameObject.FindGameObjectsWithTag("Trampoline");
        foreach (GameObject trampoline in trampolines)
        {
            Destroy(trampoline);
        }
    }
}