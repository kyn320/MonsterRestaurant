using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIRecipeInventory : UIListView
{

    List<int> itemList;

    [SerializeField]
    UIDetailView detailView;

    private void Start()
    {
        CreateSlot();
    }

    public override void CreateSlot()
    {
        listCount = Inventory.GetRecipeList().Count;
        for (int t = 0; t < listCount; t++)
        {
            if (t >= slotList.Count)
            {
                UIRecipeSlot s = Instantiate(slotPrefab, viewTransform).GetComponent<UIRecipeSlot>();
                slotList.Add(s);
            }
        }
        UpdateSlot();

    }

    public override void UpdateSlot()
    {
        itemList = Inventory.GetRecipeList();

        for (int i = 0; i < slotList.Count; i++)
        {
            UIListSlot s = slotList[i];
            if (i >= itemList.Count)
            {
                s.SetSlot(-1, null, "", "");
                ((UIRecipeSlot)s).combinationClickEvent = null;
            }
            else
            {
                RecipeData item = RecipeDB.Instance.FindItem(itemList[i]);
                ((UIRecipeSlot)s).combinationClickEvent = OpenDetail;
                ((UIRecipeSlot)s).SetSlot(i, item.Icon, item.Name, item.Context, item.Combination, item.Price);
            }
        }
        GetComponent<RectTransform>().ForceUpdateRectTransforms();
    }

    public void OpenDetail(int _index)
    {
        //TODO :: 아이템 상세 정보창 띄우기
        ItemData item = ItemDB.Instance.FindItem(_index);

        if (item == null)
            return;

        //정보창에 아이템 데이터 세팅
        detailView.SetData(item.Name, item.Icon, item.Context);
        detailView.OpenView();
    }


}
