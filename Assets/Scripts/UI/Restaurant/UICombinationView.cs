using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombinationView : MonoBehaviour
{
    public Text recipeText;

    public RectTransform contentTransform;

    public List<UICombinationSlot> slotList;

    public GameObject slot;

    public int index;

    [SerializeField]
    Vector2 startPos;
    
    [SerializeField]
    Vector2 slotSize;

    public void CreateCombination(List<int> idList)
    {
        for (int i = 0; i < idList.Count; ++i)
        {
            if (i + 1 >= slotList.Count)
            {
                GameObject g = Instantiate(slot, contentTransform);
                slotList.Add(g.GetComponent<UICombinationSlot>());
            }

            slotList[i].SetIcon(ItemDB.Instance.FindItem(idList[i]).Icon);
        }

        UpdateIndex();
    }
    // 600 >> 480 == 120

    public void UpdateIndex()
    {
        ++index;

        if (updateView != null)
            StopCoroutine(updateView);

        updateView = StartCoroutine(UpdateView());
    }

    public void ResetIndex() {
        index = -1;

        if (updateView != null)
            StopCoroutine(updateView);

        updateView = StartCoroutine(UpdateView());
    }

    Coroutine updateView = null;

    IEnumerator UpdateView()
    {
        while (true)
        {
            contentTransform.anchoredPosition = Vector2.Lerp(contentTransform.anchoredPosition, startPos + Vector2.left * slotSize.x * index, Time.deltaTime);

            if ((contentTransform.anchoredPosition - (startPos + Vector2.left * slotSize.x * index)).normalized.x < 0.3f)
            {
                break;
            }
            yield return null;
        }

        contentTransform.anchoredPosition = startPos + Vector2.left * slotSize.x * index;
        updateView = null;
    }

}
