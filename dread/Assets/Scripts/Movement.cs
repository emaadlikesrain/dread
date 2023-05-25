using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float rollSpeed = 20f;
    public float slowdownFactor = 0.5f;

    public float sprintCooldownDuration = 3f;
    private bool isSprinting = false;
    private float sprintCooldownTimer = 0f;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isRolling = false;
    private bool isSlowed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        if (movement.magnitude > 0f)
        {
            if (!isSlowed)
                movement *= speed;
            else
                movement *= speed * slowdownFactor;
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

        // Check for sprint input and cooldown
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting && sprintCooldownTimer <= 0)
        {
            StartSprinting();
        }

        // Perform sprinting actions
        if (isSprinting)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !isSlowed)
            {
                rb.velocity = movement.normalized * sprintSpeed;
                animator.SetFloat("Speed", 2f);
            }
            else
            {
                StopSprinting();
            }
        }

        // Update sprint cooldown timer
        if (sprintCooldownTimer > 0)
        {
            sprintCooldownTimer -= Time.deltaTime;
        }

        // Check if the cooldown timer reaches or goes below zero
        if (sprintCooldownTimer <= 0)
        {
            sprintCooldownTimer = 0;
        }
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

    void StartSprinting()
    {
        isSprinting = true;
        sprintCooldownTimer = sprintCooldownDuration;
    }

    void StopSprinting()
    {
        isSprinting = false;
    }
}
