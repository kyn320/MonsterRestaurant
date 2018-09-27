using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGauge : MonoBehaviour
{
    private Slider slider;

    [SerializeField]
    float currentValue;
    [SerializeField]
    float minValue, maxValue;

    public Text nameText, valueText;

    public bool isInt = false;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.wholeNumbers = isInt;
    }

    public void SetGauge(string _name, float _min, float _max, float _value)
    {
        if (_name != null)
            nameText.text = _name;

        slider.minValue = minValue = _min;
        slider.maxValue = maxValue = _max;
        UpdateValue(_value);
    }

    public void UpdateValue(float _value)
    {
        currentValue = Mathf.Clamp(_value, minValue, maxValue);
        slider.value = currentValue;
        valueText.text = string.Format("{0} / {1}", currentValue, maxValue);
    }


}
