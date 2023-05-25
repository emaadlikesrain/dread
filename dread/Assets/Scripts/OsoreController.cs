using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OsoreController : MonoBehaviour
{
    public float speed = 5f;
    public float attackDistance = 2f;
    public float avoidDistance = 5f;
    public int maxHealth = 125;
    public int currentHealth;
    public int damage = 25;
    private Rigidbody2D rb;

    public GameObject door;

    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        else if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            Attack();
        }
        else if (Vector2.Distance(transform.position, player.position) <= avoidDistance)
        {
            Avoid();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rb.MovePosition(transform.position);
    }

    void Attack()
    {
        isAttacking = true;
        // Add attack animation or sound effect here
    }

    void Avoid()
    {
        isAttacking = false;
        // Add avoid animation or sound effect here
        transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        rb.MovePosition(transform.position);
    }

    void Die()
    {
        // Spawn door prefab
        door.SetActive(true);
        // Destroy Osore object
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAttacking)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}