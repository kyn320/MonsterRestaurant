using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDetailView : MonoBehaviour
{
    public Text nameText;
    public Image iconImage;
    public Text contextText;
    
    public void SetData(string _name, Sprite _icon, string _context)
    {
        nameText.text = _name;
        iconImage.sprite = _icon;
        contextText.text = _context;
    }

    public void OpenView()
    {
        gameObject.SetActive(true);
    }

    public void CloseView()
    {
        gameObject.SetActive(false);
    }

}
