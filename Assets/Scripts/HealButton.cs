using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private int _restoredHealth;

    public void OnButtonPressed()
    {
        EventManager.OnHealPressed(_restoredHealth);
    }
}
