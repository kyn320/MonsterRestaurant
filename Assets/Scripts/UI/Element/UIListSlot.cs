using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListSlot : UISlot
{
    public Text nameText;
    public Text contextText;

    public virtual void SetSlot(int _index, Sprite _icon, string _name, string _context)
    {

        index = _index;

        iconImage.sprite = _icon;
        nameText.text = _name;
        _context = _context.Replace("\\n","\n");
        contextText.text = _context;

    }
    
}
