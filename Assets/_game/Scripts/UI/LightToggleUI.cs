using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;

public class LightToggleUI : MonoBehaviour
{
    private Lightsystem LightSystem;
    public Toggle ToggleLight;

    private void Awake()
    {
        LightSystem = FindAnyObjectByType<Lightsystem>();
        LightSystem.OnIsActiveChanged += LightStateChange;
    }

    void LightStateChange(bool isActive)
    {
        ToggleLight.isOn = isActive;
    }
}
