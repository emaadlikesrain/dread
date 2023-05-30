using UnityEngine;

public class TutorialDummy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
            if (tutorialManager != null)
            {
                tutorialManager.SetDialogueText("nice hit.");
                gameObject.SetActive(false);
            }
        }
    }
}