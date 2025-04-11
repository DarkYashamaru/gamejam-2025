using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float Maxheathvalue = 10000f;
    public float Currentheathvalue = 0;
    public event System.Action OnDeath;
    public event System.Action<float> OnHealthChanged;
    private void Start()
    {
        Currentheathvalue = Maxheathvalue;
        OnHealthChanged?.Invoke(Currentheathvalue);
    }

    public void TakeDamage(float damage)
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
