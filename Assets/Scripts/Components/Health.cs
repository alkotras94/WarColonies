using System;

public class Health
{
    public Health(float maxHealth)
    {
        if (maxHealth < 0)
            throw new ArgumentOutOfRangeException();

        CurrentHealth = maxHealth;
        MaxHealth = maxHealth;
    }

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public event Action Changed;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        CurrentHealth -= damage;

        Changed?.Invoke();

        Math.Clamp(CurrentHealth,0, MaxHealth);
    }

    public void AddHealth(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        CurrentHealth += value;

        Math.Clamp(CurrentHealth,0,MaxHealth);

        Changed?.Invoke();
    }
}
