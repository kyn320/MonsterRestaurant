using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : UIGridView
{
    List<int> itemList;
    List<int> itemCountList;

    public Text goldText;

    [SerializeField]
    UIDetailView detailView;

    private void Start()
    {
        ViewGold(Inventory.GetGold());
        CreateSlot();
    }

    public void ViewGold(int _gold)
    {
        goldText.text = string.Format("{0}G", _gold);
    }


    public override void UpdateSlot()
    {
        itemList = Inventory.GetItemList();
        itemCountList = Inventory.GetItemCountList();

        for (int i = 0; i < slotList.Count; i++)
        {
            UIGridSlot s = slotList[i];
            if (i >= itemList.Count)
            {
                s.SetSlot(-1, null, 0);
                s.clickEvent += OpenDetail;
            }
            else
            {
                ItemData item = ItemDB.Instance.FindItem(itemList[i]);
                s.SetSlot(i, item.Icon, itemCountList[i]);
                s.clickEvent = OpenDetail;
            }
        }
    }

    public void OpenDetail(int _index)
    {
        //TODO :: 아이템 상세 정보창 띄우기
        ItemData item = ItemDB.Instance.FindItem(itemList[_index]);

        if (item == null)
            return;

        //정보창에 아이템 데이터 세팅
        detailView.SetData(item.Name, item.Icon, item.Context);
        detailView.OpenView();
    }

}
