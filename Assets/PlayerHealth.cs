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
    public float minSize = 0.2f;
    public float maxSize = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        UpdateSlimeSize();
    }

    void Update()
    {
        // Always keep size in sync with health
        UpdateSlimeSize();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void UpdateSlimeSize()
    {
        float t = currentHealth / maxHealth;
        float size = Mathf.Lerp(minSize, maxSize, t);
        transform.localScale = new Vector3(size, size, 1f);
    }

    void Die()
    {
        Debug.Log("Player died");
        Time.timeScale = 0f;
    }
}
