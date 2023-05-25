using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class born : MonoBehaviour
{
    public string targetSceneName; // The name of the scene you want to load

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
