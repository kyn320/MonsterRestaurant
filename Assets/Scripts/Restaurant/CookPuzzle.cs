using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzle : MonoBehaviour
{
    public ItemData item;

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

    public void SetItem(ItemData _item)
    {
        item = _item;

        icon.sprite = item.Icon;
    }

    public void SetRandomItem()
    {
        SetItem(ItemDB.Instance.FindItem(Random.Range(1, 11)));
    }

    public ItemData GetItem()
    {
        if (item.Name == "" || item.ID == -1)
            return null;


        return item;
    }
}
