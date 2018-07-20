using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzle : MonoBehaviour
{
    public Item item;

    public bool isSelect = false;

    public void SetSelect(bool _isSelect)
    {
        isSelect = _isSelect; 
    }

    public bool GetSelect()
    {
        return isSelect;
    }

}
