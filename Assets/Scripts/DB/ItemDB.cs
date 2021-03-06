﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : Singleton<ItemDB>
{
    readonly string dataPath = "Data/";

    public Item items;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadItemDB();
    }

    void LoadItemDB()
    {
        items = Resources.Load<Item>(dataPath + "Item");
    }

    public ItemData FindItem(int _id)
    {
        return items.FindItemID(_id);
    }

    public ItemData GetRandomItem()
    {
        return items.GetRandomItem();
    }

}
