using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DreadController : MonoBehaviour
{
    public float speed = 3f;
    public float attackDistance = 2f;
    public float avoidDistance = 5f;
    public int maxHealth = 500;
    public int currentHealth;
    public int damage = 34;
    //private Rigidbody2D rb;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private Transform player;
    private bool isAttacking = false;
    private bool isMoving = false;
    private bool isShooting = false;

    private bool shouldMoveTowardsPlayer = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        //rb = GetComponent<Rigidbody2D>();
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
        if (!isMoving)
        {
            StartCoroutine(MoveCoroutine());
        }
    }

    IEnumerator MoveCoroutine()
    {
        isMoving = true;

        if (shouldMoveTowardsPlayer)
        {
            Vector2 targetPosition = player.position;
            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            Vector2 targetPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f));
            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        // Toggle the movement mode
        shouldMoveTowardsPlayer = !shouldMoveTowardsPlayer;

        isMoving = false;
    }

    void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        // play attack animation or sound effect here
        yield return new WaitForSeconds(1f);
        Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        isAttacking = false;
    }

    void Avoid()
    {
        if (!isMoving)
        {
            StartCoroutine(AvoidCoroutine());
        }
    }

    IEnumerator AvoidCoroutine()
    {
        isMoving = true;
        Vector2 avoidPosition = transform.position + (transform.position - player.position).normalized * avoidDistance;
        while (Vector2.Distance(transform.position, avoidPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, avoidPosition, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("win");
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
