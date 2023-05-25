using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public float speed = 5f; // The speed at which the rat moves
    public int damage = 10; // The amount of damage the rat deals to the player
    public int maxHealth = 50;
    public int currentHealth;

    private Transform target; // A reference to the player's transform

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play death animation, disable collider, etc.
        Destroy(gameObject);
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        target.GetComponent<RatEnemy>().SetTarget(target);
    }

    public void SetTarget(Transform newTarget)
    {
        // Set the target to the new target
        target = newTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
