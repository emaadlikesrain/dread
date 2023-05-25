using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 50;

    private Transform playerTransform;
    private Vector3 target;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        target = playerTransform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}