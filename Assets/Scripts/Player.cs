using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zıplama kontrolü (yerdeyken)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Oyuncu girişini al
        float horizontalInput = Input.GetAxis("Horizontal");

        // Hareket vektörünü oluştur
        Vector2 movement = new Vector2(horizontalInput, 0);

        // Hareket vektörünü normalleştir
        movement.Normalize();

        // Oyuncuyu hareket ettir
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yerde olup olmadığını kontrol et
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Yerde olup olmadığını kontrol et
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
