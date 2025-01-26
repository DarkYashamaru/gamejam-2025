using UnityEngine;

public class SystemBase : MonoBehaviour
{
    public int cost;
    protected HealthSystem _healthSystem;
    
    protected virtual void Awake()
    {
        _healthSystem = FindAnyObjectByType<HealthSystem>();
    }
    
}




