using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class SystemToggle : SystemBase
{
    public float Delay = 0.1f;
    protected float CurrentDelay = 0f;
    public bool IsActive = true;

    protected void Start()
    {
        CurrentDelay = Delay;
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