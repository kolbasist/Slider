using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{       
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _initialHealth;
    [SerializeField] private UnityEvent<int> _heroHealthChanged; 
    [SerializeField] private UnityEvent<int> _heroMaxHealthEstablished;
   
    private int _health =  0;
    private int _minHealth = 0;

    private void OnEnable()
    {
        _heroMaxHealthEstablished.Invoke(_maxHealth);
        if (_initialHealth <= _maxHealth || _initialHealth >= _minHealth)
           ChangeHealthValue(_initialHealth);
        else 
            ChangeHealthValue((int)Mathf.Clamp(_minHealth, _maxHealth, _initialHealth));
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            ChangeHealthValue(-damage);
    }

    public void Heal(int restoredHealth)
    {
        if (restoredHealth > 0)
            ChangeHealthValue(restoredHealth);
    }

    private void ChangeHealthValue(int healthDelta)
    {
        _health = Mathf.Clamp(_health + healthDelta, _minHealth, _maxHealth);
        _heroHealthChanged.Invoke(_health);
    }
}
