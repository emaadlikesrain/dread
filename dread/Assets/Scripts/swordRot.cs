using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordRot : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 10f;
    public float swingDistance = 1f;

    private void Update()
    {
        if (Input.GetMouseButton(0)) // Check for left mouse button press
        {
            // Step 1: Get mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Step 2: Convert mouse position to world coordinates
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseWorldPosition.z = 0f; // Assuming the sword is on the same Z-axis as the player

            // Step 3: Calculate direction vector
            Vector3 direction = mouseWorldPosition - player.transform.position;

            // Step 4: Calculate angle in radians
            float angleRad = Mathf.Atan2(direction.y, direction.x);

            // Step 5: Convert angle to degrees
            float angleDeg = Mathf.Rad2Deg * angleRad;

            // Step 6: Apply rotation to the pivot GameObject
            transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);

            // Step 7: Calculate the position of the sword
            Vector3 swordPosition = player.transform.position + direction.normalized * swingDistance;

            // Step 8: Set the position of the sword
            transform.GetChild(0).position = swordPosition;
        }
    }
}