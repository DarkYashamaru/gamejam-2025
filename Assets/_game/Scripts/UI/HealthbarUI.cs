using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{

    public Slider Fastbar;
    public Image FastbarGraphic;
    public Slider Slowbar;
    public Image SlowbarGraphic;
    private HealthSystem healthSystem;
    private float TargetValue;
    public float SlowBarSpeed = 0.1f;
    public Color fullbarColor = Color.green;
    public Color halfbarColor = Color.yellow;
    public Color lowbarColor = Color.red;

    private void Awake()
    {
        healthSystem = FindAnyObjectByType<HealthSystem>();
        healthSystem.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        float currentvalue = value / healthSystem.Maxheathvalue;
        Fastbar.value = currentvalue;
        TintHealthBar(FastbarGraphic, currentvalue);
        
        TargetValue = currentvalue;
    }

    private void Update()
    {
        Slowbar.value = Mathf.MoveTowards(Slowbar.value, TargetValue, Time.deltaTime * SlowBarSpeed);
        TintHealthBar(SlowbarGraphic, Slowbar.value);
    }

    public void TintHealthBar(Image image, float value)
    {
        float a = image.color.a;
        image.color = fullbarColor;
        
        if (value < 0.51f)
        {
            image.color = halfbarColor;
        }

        if (value < 0.26f)
        {
            image.color = lowbarColor;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, a);
    }
}
