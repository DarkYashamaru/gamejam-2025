using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Maxheathvalue = 10000;
    public int Currentheathvalue = 0;
    public event System.Action OnDeath;
    public event System.Action<int> OnHealthChanged;
    private void Start()
    {
        Currentheathvalue = Maxheathvalue;
    }

    public void TakeDamage(int damage)
    {
        Currentheathvalue -= damage;

        if (Currentheathvalue <= 0)
        {
            Currentheathvalue = 0;
            OnDeath?.Invoke();
        }
        
        OnHealthChanged?.Invoke(Currentheathvalue);
    }
}
