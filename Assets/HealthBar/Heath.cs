using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Heath : MonoBehaviour
{
    public UnityEvent OnDeath = new();
    public UnityEvent<float> OnChangeHealth = new();

    [SerializeField] private float _maxHeath;
    [SerializeField] private float _currentHealth;

    public float MaxHealth => _maxHeath;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHeath;
        OnChangeHealth?.Invoke(_currentHealth);
    }

    public void TakeDamage(float value)
    {
        _currentHealth -= value;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }

        OnChangeHealth?.Invoke(_currentHealth);
    }

    public void RestoreHealth(float value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHeath)
        {
            _currentHealth = _maxHeath;
        }

        OnChangeHealth?.Invoke(_currentHealth);
    }
}
