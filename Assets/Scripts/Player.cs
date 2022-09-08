using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _maxHealth;

    public float DisplayedHealth => Mathf.Clamp01(_health);

    private int _minHealth = 0;
    private float _health;
    private Animator _animator;
    private float _defaultHealthMultiplyer = 0.5f;

    private void Start()
    {
        if (_initialHealth >= _maxHealth || _initialHealth <= _minHealth)
            _initialHealth = Convert.ToInt32(Mathf.Lerp((float)_minHealth, (float)_maxHealth, _defaultHealthMultiplyer));
        Debug.Log(_initialHealth);

        _animator = GetComponent<Animator>();
        _health = (float)_initialHealth / (float)_maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0 )
        {
            _health = Mathf.MoveTowards(_health, _minHealth, (float) damage/_maxHealth);
            Debug.Log(_health*_maxHealth);
        }
        else
            Die();
    }

    private void Die()
    {

    }
}
