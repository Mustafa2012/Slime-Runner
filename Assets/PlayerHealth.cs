using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI")]
    public Image healthBarFill;

    [Header("Slime Size")]
    public float minSize = 0.3f;
    public float maxSize = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealth();
    }

    void UpdateHealth()
    {
        // Update UI
        if (healthBarFill != null)
            healthBarFill.fillAmount = currentHealth / maxHealth;

        // Map health to slime size
        float size = Mathf.Lerp(minSize, maxSize, currentHealth / maxHealth);
        transform.localScale = Vector3.one * size;
    }
}
