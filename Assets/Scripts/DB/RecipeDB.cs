using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDB : Singleton<RecipeDB>
{
    readonly string dataPath = "Data/";

    public Recipe items;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadItemDB();
    }

    void LoadItemDB()
    {
        items = Resources.Load<Recipe>(dataPath + "Recipe");
    }

    public RecipeData FindItem(int _id)
    {
        return items.FindItemID(_id);
    }

    public RecipeData GetRandomItem()
    {
        return items.GetRandomItem();
    }

}
