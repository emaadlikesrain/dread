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
        if (difficulty == Difficulty.Easy)
        {
            SceneManager.LoadScene("manic_levelOne");
        }
        if (difficulty == Difficulty.Medium)
        {
            SceneManager.LoadScene("panic_levelOne");
        }
        if (difficulty == Difficulty.Hard)
        {
            SceneManager.LoadScene("tragic_levelOne");
        }

    }
}
