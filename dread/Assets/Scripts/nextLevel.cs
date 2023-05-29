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
            if (currentScene.name == "manic_levelOne")
            {
                SceneManager.LoadScene("manic_levelTwo");
            }

            if (currentScene.name == "manic_levelTwo")
            {
                SceneManager.LoadScene("manic_levelThree");
            }

            if (currentScene.name == "panic_levelOne")
            {
                SceneManager.LoadScene("panic_levelTwo");
            }

            if (currentScene.name == "panic_levelTwo")
            {
                SceneManager.LoadScene("panic_levelThree");
            }

            if (currentScene.name == "tragic_levelOne")
            {
                SceneManager.LoadScene("tragic_levelTwo");
            }

            if (currentScene.name == "tragic_levelTwo")
            {
                SceneManager.LoadScene("tragic_levelThree");
            }
        }
    }
}