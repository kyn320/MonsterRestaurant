using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

    public NPCType type;

    public NPCData npcData;



}

[System.Serializable]
public enum NPCType
{
    None,
    Civilian,
    Customer
}