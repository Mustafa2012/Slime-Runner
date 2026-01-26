using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("Death Scene")]
    public string deathScene = "GameOverScene"; // Scene to load on death

    public bool IsDead { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        IsDead = false;
        UpdateHealth();
    }

    public void TakeDamage(float amount)
    {
        if (IsDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealth();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PLAYER DIED");
        IsDead = true;
        currentHealth = 0f;

        // Load the death scene
        SceneManager.LoadScene(deathScene);
    }

    void UpdateHealth()
    {
        // Update health bar UI
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }

        // Scale slime based on health
        float size = Mathf.Lerp(minSize, maxSize, currentHealth / maxHealth);
        transform.localScale = Vector3.one * size;
    }
}
