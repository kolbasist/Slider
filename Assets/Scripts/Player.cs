using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{      
    private Animator _animator;    
    private HashAnimatorNames _hashAnimatorNames = new HashAnimatorNames();
    private float _dizzyMutipyer = 0.2f;
    private bool _isDizzy;

    private void Start()
    {       
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //if (_health > _maxHealth * _dizzyMutipyer && _isDizzy)
        //{
        //    _isDizzy = false;
        //    _animator.SetTrigger(_hashAnimatorNames.IdleHash);
        //}
        //else if (_health <= _maxHealth * _dizzyMutipyer && _isDizzy == false)
        //{
        //    _isDizzy = true;
        //    _animator.SetTrigger(_hashAnimatorNames.DizzyHash);
        //}
    }    
}
