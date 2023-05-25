using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float distanceFromPlayer = 1f;
    public GameObject door;
    public GameObject osore;
    public GameObject dread;
    public int ratsToDefeat = 10;
    public int ratsKilled = 0;
    public int damage = 20;
    private bool isSwinging = false;
    private OsoreController osoreScript;
    private DreadController dreadScript;

    private Animator animator;
    private Transform playerTransform;
    private Vector3 mousePosition;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        osoreScript = osore.GetComponent<OsoreController>();
        dreadScript = dread.GetComponent<DreadController>();

        // Changes: Assign Animator component using GetComponentInChildren
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject");
        }
        Debug.Log("Animator component found");
    }

    private void Update()
    {
        // Move sword to follow mouse cursor
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        // Move sword to be in front of player
        Vector3 playerPosition = playerTransform.position;
        playerPosition.z = 0f;
        transform.position = playerPosition + (transform.position - playerPosition).normalized * distanceFromPlayer;

        if (Input.GetMouseButtonDown(0) && isSwinging == false)
        {
            Debug.Log("clicked");
            isSwinging = true;
            if (animator != null)
            {
                Debug.Log("Animator component found");
                animator.SetBool("IsSwinging", true);
                StartCoroutine(StopAttacking());
            }
            else
            {
                Debug.Log("Animator component not found on the GameObject");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rat"))
        {
            Destroy(collision.gameObject);
            ratsKilled++;

            if (ratsKilled >= ratsToDefeat)
            {
                door.SetActive(true);
            }
        }

        if (collision.CompareTag("Osore"))
        {
            if (osoreScript.currentHealth > 0)
            {
                osoreScript.currentHealth -= damage;
            }
        }

        if (collision.CompareTag("Dread"))
        {
            if (dreadScript.currentHealth > 0)
            {
                dreadScript.currentHealth -= damage;
            }
        }
    }

    IEnumerator StopAttacking()
    {
        yield return new WaitForSeconds(5f);
        isSwinging = false;
        if (animator != null)
        {
            animator.SetBool("IsSwinging", false);
        }
    }
}