using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzle : MonoBehaviour
{
    public Item item;

    public SpriteRenderer icon;

    public bool isSelect = false;

    public void SetSelect(bool _isSelect)
    {
        isSelect = _isSelect;
    }

    public bool GetSelect()
    {
        return isSelect;
    }

    public bool IsAround(CookPuzzle _puzzle)
    {

        if (_puzzle == null)
            return true;

        return (_puzzle.transform.position - transform.position).sqrMagnitude < 5f;
    }

    public void SetItem(Item _item)
    {
        item = _item;

        icon.sprite = item.icon;
    }

    public void SetRandomItem()
    {
        SetItem(ItemDB.Instance.GetRandomItem());
    }

    public Item GetItem()
    {
        if (item.name == "" || item.id == -1)
            return null;

       
        return item;
    }
}
