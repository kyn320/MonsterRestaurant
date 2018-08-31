using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDB : Singleton<MonsterDB> {

    readonly string dataPath = "Data/";

    public Monster items;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadItemDB();
    }

    void LoadItemDB()
    {
        items = Resources.Load<Monster>(dataPath + "Monster");
    }

    public MonsterData FindItem(int _id)
    {
        return items.FindItemID(_id);
    }

    public MonsterData GetRandomItem()
    {
        return items.GetRandomItem();
    }

}
