using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIField : MonoBehaviour
{
    public UIItemInventory inventory;
    
    public void OnInventory()
    {
        inventory.gameObject.SetActive(true);
    }

    public void OnMap()
    {
        SceneLoadManager.Instance.Load("WorldMap");
    }


}
