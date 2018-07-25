using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe : Item {

    public List<int> materialIDList;
    public List<int> materialCountList;
    public List<Gesture> gestureList;

    public List<Item> itemList;

    public void SetItemList() {
        for (int i = 0; i < materialIDList.Count; ++i) {
             itemList.Add(ItemDB.Instance.FindItem(materialIDList[i]));
        }
    }


}
