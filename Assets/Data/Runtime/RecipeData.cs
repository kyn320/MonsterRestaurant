using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class RecipeData
{
    [SerializeField]
    string name;
    public string Name { get { return name; } set { name = value; } }

    [SerializeField]
    int id;
    public int ID { get { return id; } set { id = value; } }

    [TextArea]
    [SerializeField]
    string context;
    public string Context { get { return context; } set { context = value; } }

    [SerializeField]
    Sprite icon;
    public Sprite Icon { get { return icon; } set { icon = value; } }

    [SerializeField]
    string combination;
    public string Combination { get { return combination; } set { combination = value; } }

    [SerializeField]
    int price;
    public int Price { get { return price; } set { price = value; } }

}