using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TurboToggleUI : MonoBehaviour
{
    private TurboSystem TurboSystem;
    public Toggle ToggleTurbine;

    private void Awake()
    {
        TurboSystem = FindAnyObjectByType<TurboSystem>();
        TurboSystem.OnIsActiveChanged += TurboStateChange;
    }

    void TurboStateChange(bool isActive)
    {
        ToggleTurbine.isOn = isActive;
    }
}
