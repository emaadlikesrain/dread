using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelection : MonoBehaviour
{
    public Button manicButton;
    public Button panicButton;
    public Button tragicButton;

    private void Start()
    {
        manicButton.onClick.AddListener(ManicButtonClicked);
        panicButton.onClick.AddListener(PanicButtonClicked);
        tragicButton.onClick.AddListener(TragicButtonClicked);
    }

    private void ManicButtonClicked()
    {
        StartGame("Manic");
    }

    private void PanicButtonClicked()
    {
        StartGame("Panic");
    }

    private void TragicButtonClicked()
    {
        StartGame("Tragic");
    }

    private void StartGame(string difficulty)
    {
        // Set the enemy's stats based on the selected difficulty
        SetEnemyStats(difficulty);

        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    private void SetEnemyStats(string difficulty)
    {
        // Adjust enemy's stats based on the selected difficulty
        switch (difficulty)
        {
            case "Manic":
                // Set enemy's stats for easy difficulty
                EnemyStats.SetEasyStats();
                break;
            case "Panic":
                // Set enemy's stats for medium difficulty
                EnemyStats.SetMediumStats();
                break;
            case "Tragic":
                // Set enemy's stats for hard difficulty
                EnemyStats.SetHardStats();
                break;
        }
    }
}
