using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIGridSlot : MonoBehaviour
{

    public int index;
    public Image itemImage;
    public Text haveText;

    public delegate void ClickEvent(int _index);
    public ClickEvent clickEvent;

   
    public virtual void SetSlot(int _index, Sprite _icon, int _value)
    {

        index = _index;

        if (_icon == null)
        {
            itemImage.enabled = false;
        }
        else
        {
            itemImage.enabled = true;
            itemImage.sprite = _icon;
        }

        if (_value > 0)
            haveText.text = string.Format("x {0}", _value);
        else
            haveText.text = "";
    }

    public void OnDetail()
    {
        clickEvent.Invoke(index);
    }


}
