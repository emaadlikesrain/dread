using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkController : MonoBehaviour
{
    [SerializeField] private float slowDownFactor = 0.5f; // Adjust this value to control the extent of slowdown

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement player = other.GetComponent<Movement>();
            player.ApplySlowdown(slowDownFactor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement player = other.GetComponent<Movement>();
            player.ResetSlowdown();
        }
    }
}
