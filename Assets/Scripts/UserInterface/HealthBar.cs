using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    public Gradient gradient;
    public Image fill;

    private Slider Slider
    {
        get
        {
            if (slider == null)
            {
                slider = gameObject.GetComponent<Slider>();
            }

            return slider;
        }
    }

    private void Start()
    {
        slider.value = 100f;
        fill.color = gradient.Evaluate(1f);
    }

    public void Init(Unit unit)
    {
        slider.maxValue = unit.attributes.maxHealth;
        slider.value = unit.attributes.health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetValue(float health)
    {
        Slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
