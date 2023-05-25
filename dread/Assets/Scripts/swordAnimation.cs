using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAnimation : MonoBehaviour
{
    public GameObject Sword;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; // Show the cursor
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction from the player to the mouse cursor
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = mousePosition - Camera.main.WorldToScreenPoint(playerTransform.position);
        direction.Normalize();

        // Rotate the sword to face the mouse cursor
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Sword.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Sword.SetActive(true);
            Cursor.visible = false; // Hide the cursor
            StartCoroutine(SwordSwing());
        }
    }

    IEnumerator SwordSwing()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(0.19f);
        Sword.GetComponent<Animator>().Play("New State");
        Sword.SetActive(false);
        Cursor.visible = true; // Show the cursor
    }
}
