using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class DifficultyHandler : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private void Start()
    {
        easyButton.onClick.AddListener(() => SelectDifficulty(Difficulty.Easy));
        mediumButton.onClick.AddListener(() => SelectDifficulty(Difficulty.Medium));
        hardButton.onClick.AddListener(() => SelectDifficulty(Difficulty.Hard));
    }

    private void SelectDifficulty(Difficulty difficulty)
    {
        // Set the selected difficulty in the GameManager

        // Load the SampleScene
        SceneManager.LoadScene("SampleScene");
    }
}
