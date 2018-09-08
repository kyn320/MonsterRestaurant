using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIGridSlot : UISlot
{
    public Text haveText;

    public virtual void SetSlot(int _index, Sprite _icon, int _value)
    {

        index = _index;

        if (_icon == null)
        {
            iconImage.enabled = false;
        }
        else
        {
            iconImage.enabled = true;
            iconImage.sprite = _icon;
        }

        if (_value > 0)
            haveText.text = string.Format("x {0}", _value);
        else
            haveText.text = "";
    }

}
