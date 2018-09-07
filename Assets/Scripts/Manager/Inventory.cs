using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    public List<int> itemList;
    public List<int> itemCountList;

    public List<int> recipeList;
    public List<int> recipeCountList;

    public List<int> equipList;

    public int gold;

    public UnityAction<int> goldEvent;

    public static void AddGold(int _value)
    {
        Instance.gold += _value;
        Instance.goldEvent.Invoke(Instance.gold);
    }

    public static void SubGold(int _value)
    {
        Instance.gold -= _value;
        Instance.goldEvent.Invoke(Instance.gold);
    }

    public static void AddItem(int _itemID, int _value)
    {
        int index = -1;
        index = Instance.itemList.FindIndex(item => item == _itemID);

        if (index != -1)
        {
            //아이템 갯수 추가
            Instance.itemCountList[index] += _value;
        }
        else
        {
            //아이템 추가 및 갯수 추가
            Instance.itemList.Add(_itemID);
            Instance.itemCountList.Add(1);
        }

    }

    public static void SubItem(int _itemID, int _value)
    {
        int index = -1;
        index = Instance.itemList.FindIndex(item => item == _itemID);

        if (index != -1)
        {
            //인벤토리 검색
            int have = Instance.itemCountList[index];

            if (have - _value >= 0)
            {
                //감소 성공
                Instance.itemCountList[index] -= _value;
            }
            else
            {
                //감소 실패 >> 아이템이 부족함
                //TODO::감소 불가능 전달
            }

        }
        else
        {
            //아이템이 존재 하지 않음
            //TODO::아이템이 존재하지 않음
        }
    }

    public static List<int> GetItemList()
    {
        return Instance.itemList;
    }

    public static List<int> GetItemCountList()
    {
        return Instance.itemCountList;
    }

    public static int GetGold()
    {
        return Instance.gold;
    }

}
