using UnityEngine;
using UnityEngine.UI;

public class SliderValueSetter : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    private void FixedUpdate()
    {
        //_slider.value = _player.DisplayedHealth;
    }
}
