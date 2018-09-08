using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWorldMap : MonoBehaviour
{

    [SerializeField]
    UIItemInventory inventoryView;
    [SerializeField]
    UINpcHire npcHireView;

    public void OnHunter()
    {
        npcHireView.OpenView(1);
    }

    public void OnGatherer()
    {
        npcHireView.OpenView(2);
    }

    public void OnInventory()
    {
        inventoryView.OpenView();
    }

    public void OnEquip()
    {

    }

    public void OnLoadMap(string _category)
    {
        SceneLoadManager.Instance.Load(_category);
    }
    public void OnMain()
    {
        SceneLoadManager.Instance.Load("Title");
    }

}
