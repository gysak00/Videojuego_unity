using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public int health = 3;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject gameOverImg;

    public bool isDead;

    void Start()
    {
        Time.timeScale = 1; // Asegura que el tiempo esté normal al iniciar
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
<<<<<<< Updated upstream
=======
        health = maxHealth;   // vida inicial
        gameOverImg.SetActive(false);
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Movimiento lateral
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Revisar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Simular daño con Q
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     TakeDamage();
        // }
    }

    void TakeDamage()
    {
        health--;

        if (health > 0)
        {
            anim.SetTrigger("Hurt");  // animación de recibir daño
        }
        else
        {
            Time.timeScale = 0;       // pausar el juego
            gameOverImg.SetActive(true);
            anim.SetTrigger("Death");   // animación de muerte

            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
<<<<<<< Updated upstream
=======

    IEnumerator Immunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityTime);
        isImmune = false;
    }

>>>>>>> Stashed changes
    
}
