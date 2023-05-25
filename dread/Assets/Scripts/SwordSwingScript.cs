using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingScript : MonoBehaviour
{
    public GameObject door;
    public GameObject osore;
    public GameObject dread;
    public GameObject ratskull;
    public int ratsToDefeat = 10;
    public int ratsKilled = 0;
    public int damage = 20;
    private OsoreController osoreScript;
    private DreadController dreadScript;
    private RatskullController ratskullScript;

    private void Start()
    {
        osoreScript = osore.GetComponent<OsoreController>();
        dreadScript = dread.GetComponent<DreadController>();
        ratskullScript = ratskull.GetComponent<RatskullController>();
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

        if (collision.CompareTag("RatSkull"))
        {
            if (ratskullScript.currentHealth > 0)
            {
                ratskullScript.currentHealth -= damage;
            }
        }
    }
}
