using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plant   {

    public string name;
    public int id;
    public int spendSP;
    public float gatheringTime;
    public float perfectGatheringPercent;
    public List<int> dropItemList;
    public GameObject prefab;


}
