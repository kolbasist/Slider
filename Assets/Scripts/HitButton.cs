using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private int _hitDamage;  

    public void OnButtonPressed()
    {
        EventManager.OnHitPressed(_hitDamage);
    }
}
