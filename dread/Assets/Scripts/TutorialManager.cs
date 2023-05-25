using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject tutorialDummy;

    private int currentDialogueIndex = 0;
    private string[] dialogueTexts = {
        "Welcome to the tutorial!",
        "Use the WASD keys to move around.",
        "Press the left mouse button to attack the dummy.",
        "Great job! You're ready to explore level 1 now!"
    };

    private void Start()
    {
        tutorialDummy.SetActive(true);
    }

    public void StartTutorial()
    {
        SetDialogueText(dialogueTexts[currentDialogueIndex]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentDialogueIndex < dialogueTexts.Length - 1)
            {
                currentDialogueIndex++;
                SetDialogueText(dialogueTexts[currentDialogueIndex]);
            }
            else
            {
                StartLevel();
            }
        }
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    private void StartLevel()
    {
        tutorialDummy.SetActive(false);
        // Code to start level 1
    }
}
