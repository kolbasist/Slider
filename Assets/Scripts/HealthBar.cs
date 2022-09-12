using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _changeSpeed;

    private Slider _slider;
    private float _value;    

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 1f;
    }

    public void GetHealthValue(float health)
    {
        _value = health;
        StartCoroutine(ChangeDisplayedValue());
    }

    private IEnumerator ChangeDisplayedValue()
    {        
        while (_slider.value != _value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _value, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
