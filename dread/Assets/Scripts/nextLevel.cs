using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "SampleScene")
            {
                SceneManager.LoadScene("levelTwo");
            }

            if (currentScene.name == "levelTwo")
            {
                SceneManager.LoadScene("levelThree");
            }
        }
    }
}