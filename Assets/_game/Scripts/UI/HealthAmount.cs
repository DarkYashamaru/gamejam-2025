using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthAmount : MonoBehaviour
{
    private HealthSystem HealthSystem;
    public TextMeshProUGUI MaxHealthText;
    public TextMeshProUGUI CurrentHealthText;

    private void Awake()
    {
        HealthSystem = FindAnyObjectByType<HealthSystem>();
        HealthSystem.OnHealthChanged += HealthNums;
    }

    private void Start()
    {
        MaxHealthText.text = HealthSystem.Maxheathvalue.ToString("F0");
    }

    private void HealthNums(float obj)
    {
        CurrentHealthText.text = obj.ToString("F0");
    }
}
