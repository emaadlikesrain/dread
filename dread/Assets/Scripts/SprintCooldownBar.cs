using UnityEngine;
using UnityEngine.UI;

public class SprintCooldownBar : MonoBehaviour
{
    public Slider cooldownSlider;
    public float cooldownDuration = 3f;
    private float cooldownTimer = 0f;
    private bool isCoolingDown = false;

    private void Update()
    {
        if (isCoolingDown)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownSlider.value = cooldownTimer;

            if (cooldownTimer <= 0f)
            {
                isCoolingDown = false;
                cooldownSlider.gameObject.SetActive(false);
            }
        }
    }

    public void StartCooldown()
    {
        cooldownTimer = cooldownDuration;
        cooldownSlider.maxValue = cooldownDuration;
        cooldownSlider.value = cooldownDuration;
        cooldownSlider.gameObject.SetActive(true);
        isCoolingDown = true;
    }
}
