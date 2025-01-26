using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class SystemToggle : SystemBase
{
    public float Delay = 0.1f;
    protected float CurrentDelay = 0f;
    protected bool isActive; 
    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
            OnIsActiveChanged?.Invoke(isActive);
        }
    }

    public event System.Action<bool> OnIsActiveChanged;
    

    protected void Start()
    {
        CurrentDelay = Delay;
        OnIsActiveChanged?.Invoke(isActive);
    }

    protected void Update()
    {
        if (!IsActive) return;
        CurrentDelay -= Time.deltaTime;

        if (CurrentDelay <= 0)
        {
            _healthSystem.TakeDamage(cost);
            CurrentDelay = Delay;
        }

    }
}