 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordRot : MonoBehaviour
{
    public GameObject player; // Reference to the player object

    private void Update()
    {
        // Step 4: Get mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Step 5: Convert mouse position to world coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0f; // Assuming the sword is on the same Z-axis as the player

        // Step 6: Calculate direction vector
        Vector3 direction = mouseWorldPosition - player.transform.position;

        // Step 7: Calculate angle in radians
        float angleRad = Mathf.Atan2(direction.y, direction.x);

        // Step 8: Convert angle to degrees
        float angleDeg = Mathf.Rad2Deg * angleRad;

        // Step 9: Apply rotation to the sword
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
    }
}
