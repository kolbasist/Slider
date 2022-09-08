using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueSetter : MonoBehaviour
{
    [SerializeField] private float _value;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    private void FixedUpdate()
    {
        _slider.value = Mathf.Lerp(0f,1f, _value);

    }
}
