using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int Health { get => health; }

    [SerializeField]
    private int maxHealth;
    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            if (value < 1)
            {
                Debug.LogError(gameObject.name + " Health system max health cannot be set for value less than 1");
                return;
            }
            maxHealth = value;
        }
    }

    [SerializeField]
    private StatBar healthBar;

    public UnityEvent OnDeath;
    public UnityEvent<int> HealthChanged;
    public UnityEvent<int> MaxHealthChanged;

    private void Start()
    {
        health = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxValue(maxHealth);
            healthBar.SetValue(health);
        }
    }

    private void OnValidate()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 0)
        {
            health = 0;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            health = 0;
            OnDeath.Invoke();
        }
        HealthChanged.Invoke(health);
        if (healthBar != null)
        {
            healthBar.SetValue(health);
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            return;
        }

        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        HealthChanged.Invoke(health);
        if (healthBar != null)
        {
            healthBar.SetValue(health);
        }
    }
}
