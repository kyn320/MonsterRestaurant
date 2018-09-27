using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{

    [SerializeField]
    Plant plant;

    GameObject collectGauge;
    UIGauge gauge;


    private void CreateGauge()
    {
        collectGauge = FindObjectOfType<UIPlantGaugeManager>().CreateGauge();
        collectGauge.GetComponent<UITargetFollow>().SetTarget(transform);
        gauge = collectGauge.GetComponent<UIGauge>();

        gauge.SetGauge(null, 0, plant.gatheringTime, 0);
        collectGauge.SetActive(false);
    }

    public void ViewGauge() {
        collectGauge.SetActive(true);
    }



}
