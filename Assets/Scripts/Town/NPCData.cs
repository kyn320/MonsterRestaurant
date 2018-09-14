using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCData
{
    public string name;
    public int id;
    [TextArea]
    public string context;

    public string likeFood;
}

public static class NPCDataUtility
{
    public static RecipeData GetRecipeToRandom(ref NPCData _data)
    {
        string[] list = _data.likeFood.Split('|');

        int rand = Random.Range(0, list.Length);

        return RecipeDB.Instance.FindItem(int.Parse(list[rand]));
    }
}
