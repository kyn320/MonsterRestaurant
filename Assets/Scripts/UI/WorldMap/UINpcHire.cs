using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINpcHire : UIListView {

    private void Start()
    {
        CreateSlot();
    }

    public override void CreateSlot()
    {
        listCount = 4;//Inventory.GetRecipeList().Count;
        for (int t = 0; t < listCount; t++)
        {
            if (t >= slotList.Count)
            {
                UINpcHireSlot s = Instantiate(slotPrefab, viewTransform).GetComponent<UINpcHireSlot>();
                slotList.Add(s);
            }
        }
        UpdateSlot();

    }

    public override void UpdateSlot()
    {
        //itemList = //Inventory.GetRecipeList();
        //
        //for (int i = 0; i < slotList.Count; i++)
        //{
        //    UIListSlot s = slotList[i];
        //    if (i >= itemList.Count)
        //    {
        //        s.SetSlot(-1, null, "", "");
        //        ((UIRecipeSlot)s).combinationClickEvent = null;
        //    }
        //    else
        //    {
        //        RecipeData item = RecipeDB.Instance.FindItem(itemList[i]);
        //        ((UIRecipeSlot)s).combinationClickEvent = OpenDetail;
        //        ((UIRecipeSlot)s).SetSlot(i, item.Icon, item.Name, item.Context, item.Combination, item.Price);
        //    }
        //}
        //GetComponent<RectTransform>().ForceUpdateRectTransforms();
    }


}
