using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRecipeSlot : UIListSlot
{
    public Image[] combinationImage;
    public Text[] combinationText;

    public Text goldText;

    public void SetData(Sprite _icon, string _name, string _context, string _combination, string _price)
    {
        SetData(_icon, _name, _context);
        SetCombination(_combination);
        goldText.text = _price.ToString();
    }


    public void SetCombination(string _combination)
    {
        string[] combination = _combination.Split('|');

        for (int i = 0; i < combination.Length; ++i)
        {
            string[] data = combination[i].Split('/');

            int id = int.Parse(data[0]);
            int value = int.Parse(data[1]);

            Sprite icon = ItemDB.Instance.FindItem(id).Icon;

            combinationImage[i].sprite = icon;
            combinationText[i].text = string.Format("x{0}", value);
        }
    }

}
