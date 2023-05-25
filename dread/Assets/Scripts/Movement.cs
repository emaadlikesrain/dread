using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float rollSpeed = 20f;
    public float slowdownFactor = 0.5f; // Add a slowdown factor variable

    private Animator animator;
    private Rigidbody2D rb;
    private bool isRolling = false;
    private bool isSlowed = false; // Add a flag to track if the player is slowed down

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        if (Input.GetKey(KeyCode.LeftShift) && !isSlowed) // Check if the player is currently slowed down
        {
            movement *= sprintSpeed;
            animator.SetFloat("Speed", 2f);
        }
        else if (movement.magnitude > 0f)
        {
            if (!isSlowed) // Check if the player is currently slowed down
                movement *= speed;
            else
                movement *= speed * slowdownFactor; // Apply slowdown effect
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            isRolling = true;
            animator.SetBool("Rolling", true);
            movement *= rollSpeed;
            StartCoroutine(StopRolling());
        }

        rb.velocity = movement;
    }

    IEnumerator StopRolling()
    {
        yield return new WaitForSeconds(1f);
        isRolling = false;
        animator.SetBool("Rolling", false);
    }

    public void ApplySlowdown(float factor)
    {
        isSlowed = true;
        slowdownFactor = factor;
    }

    public void ResetSlowdown()
    {
        isSlowed = false;
    }
}
