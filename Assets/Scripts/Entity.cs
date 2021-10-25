using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    public UnityEvent EventDie;

    public int life { get; set; } = 3;

    public void ToDamage()
    {
        --life;
        if (life == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        EventDie.Invoke();
    }
}
