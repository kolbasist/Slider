using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

static public class EventManager
{
    public static UnityEvent<int> HitButtonPressed = new UnityEvent<int>();
    public static UnityEvent<int> HealButtonPressed = new UnityEvent<int>();
    public static UnityEvent<float> HeroHealthValueChanged = new UnityEvent<float>();
    public static UnityEvent HeroDied = new UnityEvent();

    public static void OnHitPressed(int damage)
    {
        HitButtonPressed.Invoke(damage);
    }

    public static void OnHealPressed(int restoredHealth)
    {
        HealButtonPressed.Invoke(restoredHealth);
    }

    public static void OnHealthValueChanged(float scaledHealth)
    {
        HeroHealthValueChanged.Invoke(scaledHealth);
    }

    public static void OnHeroDied()
    {
        HeroDied.Invoke();
    }
}

