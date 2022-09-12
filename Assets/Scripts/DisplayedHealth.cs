using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisplayedHealth :MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _healthChanged;

    private int _health;
    private int _maxHealth;

    public void GetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        Debug.Log(_maxHealth);
    }

    public void ScaleHealth(int health)
    {
        _health = health;
        Debug.Log(_health + " " + Mathf.Clamp01((float)_health / _maxHealth) + " " + _maxHealth);
        _healthChanged.Invoke(Mathf.Clamp01((float)_health / _maxHealth));
    }
}
