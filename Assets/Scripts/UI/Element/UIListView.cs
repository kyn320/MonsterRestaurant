using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListView : MonoBehaviour
{
    public List<UIListSlot> slotList;

    public GameObject slotPrefab;

    public int listCount;

    public Transform viewTransform;


    public virtual void CreateSlot()
    {
        for (int t = 0; t < listCount; t++)
        {
            if (t >= slotList.Count)
            {
                UIListSlot s = Instantiate(slotPrefab, viewTransform).GetComponent<UIListSlot>();
                slotList.Add(s);
            }
        }
        UpdateSlot();

    }

    public virtual void UpdateSlot()
    {

    }


    public virtual void OpenView(int _type)
    {
        gameObject.SetActive(true);
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
