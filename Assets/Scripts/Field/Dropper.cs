using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    public List<int> dropItemList;
    public List<float> dropPercent;

    public int minDrop;
    public int maxDrop;

    public int minGold;
    public int maxGold;

    public GameObject dropItemPrefab;

    public float radius = 2f;

    public void SetDropList(string _itemList, string _percent, int _minDrop, int _maxDrop, int _minGold, int _maxGold)
    {
        string[] percentData = _percent.Split('/');

        string[] ItemToPercentSplit = _itemList.Split('/');

        for (int i = 0; i < percentData.Length; ++i)
        {
            string[] itemDatas = ItemToPercentSplit[i].Split('|');

            for (int k = 0; k < itemDatas.Length; ++k)
            {
                dropItemList.Add(int.Parse(itemDatas[k]));
                dropPercent.Add(float.Parse(percentData[i]));
            }

        }

        minDrop = _minDrop;
        maxDrop = _maxDrop;

        minGold = _minGold;
        maxGold = _maxGold;
    }



    public void Drop()
    {

        int randDropCount = Random.Range(minDrop, maxDrop + 1);
        int randDropGold = Random.Range(minGold, maxGold + 1);

        Vector3 pos = Vector3.zero;
        float angle = 360f / randDropCount;

        for (int i = 0; i < randDropCount; ++i)
        {
            pos.x = transform.position.x + Mathf.Cos(Mathf.Deg2Rad * angle * i) * radius;
            pos.y = transform.position.y;
            pos.z = transform.position.z + Mathf.Sin(Mathf.Deg2Rad * angle * i) * radius;

            int randomItemIndex = -1;

            while (true)
            {
                randomItemIndex = Random.Range(0, dropItemList.Count);
                if (Random.Range(0f, 100f) < dropPercent[randomItemIndex])
                {
                    break;
                }
            }

            GameObject g = Instantiate(dropItemPrefab, transform.position, Quaternion.Euler(40f, 0, 0));
            g.GetComponent<DropItem>().SetItem(dropItemList[randomItemIndex], pos);

        }

    }



}
