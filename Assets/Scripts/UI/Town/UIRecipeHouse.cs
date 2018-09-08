using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRecipeHouse : MonoBehaviour {

    public GameObject wareView;

    public GameObject studyView;

    public GameObject reinforceView;

    public UIItemInventory itemInventory;

    public void OnReinforce() {

    }



    public virtual void OpenView()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseView()
    {
        gameObject.SetActive(false);
    }

}
