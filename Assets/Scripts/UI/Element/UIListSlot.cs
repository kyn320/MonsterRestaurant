using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListSlot : MonoBehaviour
{

    public Image iconImage;

    public Text nameText;
    public Text contextText;


    public virtual void SetData(Sprite _icon, string _name, string _context)
    {

        iconImage.sprite = _icon;
        nameText.text = _name;
        contextText.text = _context;

    }

}
