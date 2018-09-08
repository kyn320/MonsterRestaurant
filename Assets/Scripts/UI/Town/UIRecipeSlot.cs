using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRecipeSlot : UIListSlot
{
    public GameObject detailView;

    public UIGridSlot[] combinationSlot;

    public ClickEvent combinationClickEvent;

    public Text goldText;

    public bool isOpen = false;

    public void SetSlot(int _index, Sprite _icon, string _name, string _context, string _combination, int _price)
    {
        base.SetSlot(_index, _icon, _name, _context);
        SetCombination(_combination);
        goldText.text = string.Format("{0}G", _price);
    }


    public void SetCombination(string _combination)
    {
        string[] combination = _combination.Split('|');

        for (int i = 0; i < combinationSlot.Length; ++i)
        {

            if (i >= combination.Length)
            {

                combinationSlot[i].SetSlot(-1, null, 0);
                combinationSlot[i].clickEvent = null;
                continue;
            }


            string[] data = combination[i].Split('/');

            int id = int.Parse(data[0]);
            int value = int.Parse(data[1]);

            Sprite icon = ItemDB.Instance.FindItem(id).Icon;

            combinationSlot[i].SetSlot(id, icon, value);
            combinationSlot[i].clickEvent = combinationClickEvent;
        }
    }

    public void ToggleDetailView()
    {
        if (isOpen)
            CloseDetailView();
        else
            OpenDetailView();
    }

    public void OpenDetailView()
    {
        detailView.SetActive(true);
        isOpen = true;
    }

    public void CloseDetailView()
    {
        detailView.SetActive(false);
        isOpen = false;
    }

}
