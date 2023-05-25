using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Transform startingPosition;
    public float speed = 5f;
    public float movementRange = 10f;
    public int damageAmount = 10; // Amount of damage to apply to the player

    private float timer;
    private Vector3 initialPosition;
    private float direction = 1f; // Added variable to control the movement direction
    private GameObject player; // Reference to the player object

    private void Start()
    {
        initialPosition = startingPosition.position;
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming the player object has the "Player" tag
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float newYPosition = Mathf.PingPong(timer * speed, movementRange);
        Vector3 newPosition = initialPosition + Vector3.up * newYPosition * direction;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            // Apply damage to the player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
