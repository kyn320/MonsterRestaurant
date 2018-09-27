using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGaugeManager : MonoBehaviour
{

    public GameObject gaugePrefab;

    public virtual GameObject CreateGauge()
    {
        return Instantiate(gaugePrefab, transform);
    }

}
