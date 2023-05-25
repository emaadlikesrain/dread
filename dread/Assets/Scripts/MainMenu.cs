using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        // Load the difficulty selection scene
        SceneManager.LoadScene("DifficultySelection");
    }
}
