using UnityEngine;

public class SystemUse : SystemBase
{
    [ContextMenu("Use")]
    public void Use()
    {
        _healthSystem.TakeDamage(cost);
    }
}
