using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{

    public int index = -1;
    public Image iconImage;

    public delegate void ClickEvent(int _index);
    public ClickEvent clickEvent;

    public void OnClickEvent()
    {
        if (index < 0 || clickEvent == null)
            return;

        clickEvent.Invoke(index);
    }

}
