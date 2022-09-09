using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _maxHealth;

    public float DisplayedHealth => Mathf.Clamp01((float)_health/_maxHealth);

    private int _minHealth = 0;
    private int _health;
    private Animator _animator;
    private float _defaultHealthMultiplyer = 0.5f;
    private HashAnimatorNames _hashAnimatorNames = new HashAnimatorNames();
    private float _dizzyMutipyer = 0.2f;
    private bool _isDizzy;

    private void Start()
    {
        if (_initialHealth >= _maxHealth || _initialHealth <= _minHealth)
            _initialHealth = Convert.ToInt32(Mathf.Lerp(_minHealth, (float)_maxHealth, _defaultHealthMultiplyer));

        _animator = GetComponent<Animator>();
        _health = _initialHealth;
        _isDizzy = _initialHealth <= _maxHealth * _dizzyMutipyer;
    }

    private void FixedUpdate()
    {
        if (_health > _maxHealth * _dizzyMutipyer && _isDizzy)
        {
            _isDizzy = false;
            _animator.SetTrigger(_hashAnimatorNames.IdleHash);
        }
        else if (_health <= _maxHealth * _dizzyMutipyer && _isDizzy == false)
        {
            _isDizzy = true;
            _animator.SetTrigger(_hashAnimatorNames.DizzyHash);
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            ChangeHealth(damage);
    }

    public void RestoreHealth( int restoredHealthPoints)
    {
        if (restoredHealthPoints > 0)
            ChangeHealth(restoredHealthPoints, false);
    }

    private void ChangeHealth(int healthDelta, bool isDamage = true)
    {
        if (isDamage)
        {
            if (healthDelta < _health)
            {
                _health = (int)Mathf.MoveTowards((float)_health, _minHealth, healthDelta);
                _animator.SetTrigger(_hashAnimatorNames.HitHash);
            }
            else if (healthDelta >= _health)
                Die();
        }
        else
        {
            if (healthDelta + _health < _maxHealth)
            {
                _health = (int)Mathf.MoveTowards((float)_health, _maxHealth, healthDelta);
                _animator.SetTrigger(_hashAnimatorNames.HealHash);
            }
            else
                Win();
        }
    }

    private void Die()
    {
        _health = 0;
        _animator.SetTrigger(_hashAnimatorNames.DieHash);       
    }

    private void Win()
    {
        _health = _maxHealth;
        _animator.SetTrigger(_hashAnimatorNames.WinHash);
    }
}
