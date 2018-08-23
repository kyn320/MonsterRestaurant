using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item  {
    public string name;
    public int id = -1;
    public Sprite icon;
    [TextArea]
    public string context;

}
