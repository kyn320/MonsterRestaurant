using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWorldMap : MonoBehaviour
{

    public void OnHunter()
    {

    }

    public void OnGatherer()
    {

    }

    public void OnInventory()
    {

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
