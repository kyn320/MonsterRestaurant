using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : Singleton<ItemDB>
{
    public List<Item> items;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Item FindItem(int _id)
    {
        return items.Find(item => item.id == _id);
    }

    public Item GetRandomItem()
    {
        return items[Random.Range(0, items.Count)];
    }

}
