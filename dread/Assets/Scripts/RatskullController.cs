using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatskullController : MonoBehaviour
{
    public int health = 1;
    public GameObject ratPrefab;
    public float spawnRate = 2f; // The rate at which rats are spawned
    public float attackDistance = 10f; // The distance at which RatSkull will start attacking the player
    public GameObject sword;
    private SwordSwingScript swordScript;
    public int maxHealth = 75;
    public int currentHealth;
    public int damage = 15;
    public int ratsNeeded = 10;

    private Transform player; // A reference to the player's transform
    private float spawnTimer = 0f; // A timer to keep track of when to spawn rats

    private bool isAttacking = false;

    void Start()
    {
        // Set up initial state
        player = GameObject.FindGameObjectWithTag("Player").transform;
        swordScript = sword.GetComponent<SwordSwingScript>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Check if health is zero
        if (currentHealth <= 0)
        {
            Die();
        }
        // Check if the player is within attack distance
        if (player != null && Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            // Start attacking
            if (swordScript.ratsKilled <= ratsNeeded)
            {
                spawnTimer += Time.deltaTime;
                if (spawnTimer >= spawnRate)
                {
                    SpawnRats();
                    spawnTimer = 0f;
                }
            }
        }
    }

    void Die()
    {
        // Destroy ratskull object
        Destroy(gameObject);
    }

    void SpawnRats()
    {
        // Instantiate the rat prefab and make them move towards the player
        GameObject rat = Instantiate(ratPrefab, transform.position, Quaternion.identity);
        rat.GetComponent<RatEnemy>().SetTarget(player);
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by the amount of damage taken
        health -= damage;
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
