using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyHandler : MonoBehaviour
{
    private enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    [SerializeField] private Difficulty selectedDifficulty;

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                selectedDifficulty = Difficulty.Easy;
                AdjustEnemyStatsForDifficulty();
                break;
            case "Normal":
                selectedDifficulty = Difficulty.Normal;
                AdjustEnemyStatsForDifficulty();
                break;
            case "Hard":
                selectedDifficulty = Difficulty.Hard;
                AdjustEnemyStatsForDifficulty();
                break;
            default:
                Debug.LogError("Invalid difficulty selection.");
                break;
        }
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the name of your game scene
    }

    private void AdjustEnemyStatsForDifficulty()
    {
        // Adjust the stats of enemies based on the selected difficulty
        switch (selectedDifficulty)
        {
            case Difficulty.Easy:
                // Adjust stats for easy difficulty
                RatskullController ratskull = FindObjectOfType<RatskullController>();
                if (ratskull != null)
                {
                    ratskull.maxHealth = 100;
                    ratskull.damage = 10;
                }
                // Adjust stats for other enemies
                // ...
                break;
            case Difficulty.Normal:
                // Adjust stats for normal difficulty
                RatskullController ratskull = FindObjectOfType<RatskullController>();
                if (ratskull != null)
                {
                    ratskull.maxHealth = 200;
                    ratskull.damage = 20;
                }
                // Adjust stats for other enemies
                // ...
                break;
            case Difficulty.Hard:
                // Adjust stats for hard difficulty
                RatskullController ratskull = FindObjectOfType<RatskullController>();
                if (ratskull != null)
                {
                    ratskull.maxHealth = 300;
                    ratskull.damage = 30;
                }
                // Adjust stats for other enemies
                // ...
                break;
            default:
                Debug.LogError("Invalid difficulty selection.");
                break;
        }
    }
}
