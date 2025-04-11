using UnityEngine;

public class SystemBase : MonoBehaviour
{
    public float cost;
    protected HealthSystem _healthSystem;
    
    protected virtual void Awake()
    {
        _healthSystem = FindAnyObjectByType<HealthSystem>();
    }
    
}




