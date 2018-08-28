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

    public bool isInt = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    

}
