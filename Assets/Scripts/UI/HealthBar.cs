using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Health _health;

    public void Initialize(Health health)
    {
        if (health == null)
            throw new NullReferenceException();

        _health = health;

    }

    public void Enable() => _health.Changed += HealthUpdate;

    public void Disable() => _health.Changed -= HealthUpdate;

    private void HealthUpdate() => _slider.value = _health.CurrentHealth / _health.MaxHealth;
}
