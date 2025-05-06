using Pixel.Manager;
using UnityEngine;

namespace Pixel.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float jumpForce = 12f;

        [Header("Ground Check")]
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;

        [Header("Jump Settings")]
        public int maxJumpCount = 2;

        private Rigidbody2D rb;
        private bool isGrounded;
        private float moveInput;
        [SerializeField] private int jumpCount;

        private Animator animator;
        private SpriteRenderer spriteRenderer;

        void Start()
        {

            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        }

        void Update()
        {
            if(!GameManager.instance.isStart) return;
            // Input
            moveInput = Input.GetAxisRaw("Horizontal");

            // Flip player
            if (moveInput != 0)
                transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

            // Jump
            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpCount--;
            }
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("IsGrounded", isGrounded);
            animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
            animator.SetInteger("JumpCount", jumpCount);
        }

        void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (isGrounded)
            {
                jumpCount = maxJumpCount;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    }

}