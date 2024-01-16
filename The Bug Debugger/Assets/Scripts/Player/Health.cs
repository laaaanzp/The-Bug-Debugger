using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Transform hpImageTransform;
    [SerializeField] private float takeDamageCooldownTime;

    [SerializeField] private UnityEvent onHit;
    [SerializeField] private UnityEvent onDeath;

    private float currentTakeDamageCooldownTime;

    private float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        currentTakeDamageCooldownTime -= Time.deltaTime;
        currentTakeDamageCooldownTime = Mathf.Max(currentTakeDamageCooldownTime, 0);
    }

    public void TakeDamage(float damage)
    {
        if (currentTakeDamageCooldownTime > 0)
            return;

        onHit?.Invoke();
        currentTakeDamageCooldownTime = takeDamageCooldownTime;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthDisplay();

        if (currentHealth == 0)
        {
            onDeath?.Invoke();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth -= healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        float hpPercentFloat = currentHealth / maxHealth;
        Vector3 hpImageTransformScale = hpImageTransform.localScale;
        hpImageTransformScale.x = hpPercentFloat;
        hpImageTransform.localScale = hpImageTransformScale;
    }
}
