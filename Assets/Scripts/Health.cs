using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _initialHealth;

    private float _defaultHealthMultiplyer = 0.5f;
    private int _health;
    private int _minHealth = 0;

    private void OnEnable()
    {
        EventManager.HitButtonPressed.AddListener(TakeDamage);
        EventManager.HealButtonPressed.AddListener(Heal);        
    }

    private void Awake()
    {
        if (_initialHealth <= _maxHealth || _initialHealth >= _minHealth)
            _health = _initialHealth;
        else 
            _health =(int)Mathf.Lerp(_minHealth, _maxHealth, _defaultHealthMultiplyer);

        EventManager.OnHealthValueChanged(Mathf.Clamp01((float)_health / _maxHealth));
    }

    private void TakeDamage(int damage)
    {
        if (damage > 0)
            ChangeHealthValue(damage);
    }

    private void Heal(int restoredHealth)
    {
        if (restoredHealth > 0)
            ChangeHealthValue(-restoredHealth);
    }

    private void ChangeHealthValue(int healthDelta)
    {
        if(Mathf.Abs(healthDelta) < _health && _health - healthDelta <= _maxHealth)
        {
            _health = (int)Mathf.MoveTowards(_health, _minHealth, healthDelta );
        }
        else if (_health - healthDelta > _maxHealth)
        {
            Win();
        }
        else if (healthDelta >= _health)
        {
            Die();
        }

        Debug.Log(_health);

        EventManager.OnHealthValueChanged(Mathf.Clamp01((float)_health / _maxHealth));
    }

    private void Die()
    {
        _health = _minHealth;
        EventManager.OnHeroDied();
    }

    private void Win()
    {
        _health = _maxHealth;
        EventManager.OnHeroHealthFilled();
    }
}
