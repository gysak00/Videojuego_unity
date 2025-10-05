using UnityEngine;
using System.Collections;   // Necesario para IEnumerator
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;

    [Header("Health")]
    public int health;
    public int maxHealth = 3;
    public Image healthImg;
    private bool isImmune;
    public float immunityTime = 1f;  // segundos de inmunidad tras recibir daño

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;   // vida inicial
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

        // ✅ CORREGIDO: conversión explícita a float
        healthImg.fillAmount = (float)health / maxHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health > 0)
        {
            anim.SetTrigger("Hurt");  // animación de recibir daño
            StartCoroutine(Immunity()); // activar inmunidad temporal
        }
        else
        {
            anim.SetTrigger("Death");   // animación de muerte
            this.enabled = false;       // desactivar movimiento
            print("player dead");       // aquí luego puedes poner pantalla de Game Over
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            // obtener daño del enemigo
            Enemy enemy = collision.GetComponent<Enemy>();
            int damageToGive = enemy != null ? enemy.damageToGive : 1; // valor por defecto 1

            TakeDamage(damageToGive);
        }
    }

    IEnumerator Immunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityTime);
        isImmune = false;
    }
}
