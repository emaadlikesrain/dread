using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject tutorialDummy;
    public Image parent;
    public float typingSpeed = 0.05f;

    private int currentDialogueIndex = 0;
    private string[] dialogueTexts = {
        "Welcome to the tutorial!",
        "Use the WASD keys to move around.",
        "Press the left mouse button to attack the dummy.",
        "Great job! You're ready to explore level 1 now!"
    };

    private bool isTyping = false;
    private string currentText = "";

    private void Start()
    {
        tutorialDummy.SetActive(false);
        StartTutorial();
    }

    public void StartTutorial()
    {
        currentDialogueIndex = 0;
        dialogueText.text = "";
        tutorialDummy.SetActive(true);
        TypeDialogueText(dialogueTexts[currentDialogueIndex]);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteText();
            }
            else if (currentDialogueIndex < dialogueTexts.Length - 1)
            {
                currentDialogueIndex++;
                TypeDialogueText(dialogueTexts[currentDialogueIndex]);
            }
            else
            {
                StartLevel();
            }
        }
    }

    private void TypeDialogueText(string text)
    {
        isTyping = true;
        currentText = "";
        dialogueText.text = currentText;
        StartCoroutine(TypeTextCoroutine(text));
    }

    private IEnumerator TypeTextCoroutine(string text)
    {
        foreach (char letter in text)
        {
            currentText += letter;
            dialogueText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;

        // Automatically proceed to the next dialogue after typing finishes
        if (currentDialogueIndex < dialogueTexts.Length - 1)
        {
            currentDialogueIndex++;
            TypeDialogueText(dialogueTexts[currentDialogueIndex]);
        }
    }

    private void CompleteText()
    {
        StopAllCoroutines();
        dialogueText.text = dialogueTexts[currentDialogueIndex];
        isTyping = false;
    }

    private void StartLevel()
    {
        tutorialDummy.SetActive(false);
        parent.enabled = false;
        // Code to start level 1
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }
}