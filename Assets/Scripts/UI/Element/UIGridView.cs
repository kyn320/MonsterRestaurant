using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UIGridView : MonoBehaviour
{
    //x
    public int rowCount;
    //y
    public int colCount;

    public List<UIGridSlot> slotList;

    public GameObject slotPrefab;

    public Transform viewTransform;

    public virtual void CreateSlot()
    {
        for (int t = 0; t < rowCount * colCount; t++)
        {
            if (t >= slotList.Count)
            {
                UIGridSlot s = Instantiate(slotPrefab, viewTransform).GetComponent<UIGridSlot>();
                slotList.Add(s);
            }
        }
        UpdateSlot();
    }

    public virtual void UpdateSlot()
    {

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
