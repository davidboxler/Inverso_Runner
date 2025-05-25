using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float slideDuration = 0.5f;
    public LayerMask obstacleLayer;
    public Transform obstacleCheckPoint;
    public float obstacleCheckDistance = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isSliding = false;
    private Vector2 originalColliderSize;
    private BoxCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        if (col != null)
        {
            originalColliderSize = col.size;
        }
        else
        {
            Debug.LogError("BoxCollider2D no encontrado en el jugador.");
        }
    }

    void Update()
    {
        // Movimiento constante hacia la derecha
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        Debug.Log("Salto");
        if (isGrounded && !isSliding)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    public void Slide()
    {
        Debug.Log("Deslizar");
        if (isGrounded && !isSliding)
        {
            isSliding = true;
            col.size = new Vector2(col.size.x, col.size.y / 2f);
            Invoke(nameof(EndSlide), slideDuration);
        }
    }

    void EndSlide()
    {
        col.size = originalColliderSize;
        isSliding = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}


