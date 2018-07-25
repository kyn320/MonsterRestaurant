using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item  {
    public string name;
    public int id = -1;
    [TextArea]
    public string context;
    public Sprite icon;

}
