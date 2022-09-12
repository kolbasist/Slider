using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerAnimations
{
    [RequireComponent(typeof(Animator))]

    public class AnimationSetter : MonoBehaviour
    {
        private Animator _animator;
        private float _dizzyMultiplyer = 0.2f;
        private bool _isDizzy;
        private float _health;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isDizzy = _health > _dizzyMultiplyer;
        }

        public void GetHealth(float health)
        {
            _health = health;
            SetAnimation();
        }

        private void SetAnimation()
        {
            if (_health == 0)
                _animator.SetTrigger(HashAnimatorNames.DieHash);
            else if (_health == 1)
                _animator.SetTrigger(HashAnimatorNames.WinHash);
            else if (_health <= _dizzyMultiplyer && _isDizzy == false)
            {
                _isDizzy = true;
                _animator.SetTrigger(HashAnimatorNames.DizzyHash);
            }
            else if (_health > _dizzyMultiplyer && _isDizzy == true)
            {
                _isDizzy = false;
                _animator.SetTrigger(HashAnimatorNames.IdleHash);
            }
        }

        public void SetHitAnimation()
        {
            _animator.SetTrigger(HashAnimatorNames.HitHash);
        }

        public void SetHealAnimation()
        {
            _animator.SetTrigger(HashAnimatorNames.HealHash);
        }
    }
}
