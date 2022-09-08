using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _initialHealth;
    [SerializeField] private float _maxHealth;

    public float DisplayedHealth => Mathf.Clamp01(_health);

    private float _minHealth = 0f;
    private float _health;
    private Animator _animator;
    private float _defaultHealthMultiplyer = 0.5f;

    private void Start()
    {
        if (_initialHealth >= _maxHealth && _initialHealth <= _minHealth)
            _initialHealth = Mathf.Lerp(_minHealth, _maxHealth, _defaultHealthMultiplyer);

        _animator = GetComponent<Animator>();
        _health = _initialHealth;
    }

    private void FixedUpdate()
    {
        
    }
}
