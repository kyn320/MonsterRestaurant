using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzleManager : MonoBehaviour
{
    public GameObject slotPrefab;

    public Vector2 slotSize;
    public Vector2 margin;

    public Vector2Int puzzleSize;

    public Recipe recipe;

    CookPuzzle[,] cookPuzzles;

    List<int> correctedItemID = new List<int>();

    private void Start()
    {
        recipe.SetItemList();
        CreatePuzzleSlot();
        SetRecipePuzzle();
        SetRandomEmptyPuzzle();
    }

    public void CreatePuzzleSlot()
    {
        cookPuzzles = new CookPuzzle[puzzleSize.x, puzzleSize.y];

        Vector2 startPos;
        startPos.x = -(puzzleSize.x - 1) * (slotSize.x + margin.x) * 0.5f;
        startPos.y = -(puzzleSize.y - 1) * (slotSize.y + margin.y) * 0.5f;

        for (int x = 0; x < puzzleSize.x; ++x)
        {
            for (int y = 0; y < puzzleSize.y; ++y)
            {
                GameObject g = Instantiate(slotPrefab, transform);
                g.transform.localPosition = new Vector3(startPos.x + x * (slotSize.x + margin.x), startPos.y + y * (slotSize.y + margin.y));
                cookPuzzles[x, y] = g.GetComponent<CookPuzzle>();
            }
        }
    }

    public void SetRecipePuzzle()
    {
        List<Vector2Int> isUseVec2 = new List<Vector2Int>();
        Vector2Int startPos = new Vector2Int(Random.Range(0, puzzleSize.x), Random.Range(0, puzzleSize.y));
        for (int i = 0; i < recipe.itemList.Count; ++i)
        {
            for (int j = 0; j < recipe.materialCountList[i]; ++j)
            {
                Vector2Int randPos;

                //랜덤 위치를 얻음
                while (true)
                {
                    int randX = Random.Range(-1, 2);
                    int randY = Random.Range(-1, 2);
                    randPos = new Vector2Int(startPos.x + randX, startPos.y + randY);

                    randPos.x = Mathf.Clamp(randPos.x, 0, puzzleSize.x - 1);
                    randPos.y = Mathf.Clamp(randPos.y, 0, puzzleSize.y - 1);

                    if (!isUseVec2.Contains(randPos))
                    {
                        isUseVec2.Add(randPos);
                        break;
                    }
                }
                correctedItemID.Add(recipe.itemList[i].id);
                cookPuzzles[randPos.x, randPos.y].SetItem(recipe.itemList[i]);
                startPos = randPos;
            }
        }
    }

    public void SetRandomEmptyPuzzle()
    {
        for (int x = 0; x < puzzleSize.x; ++x)
        {
            for (int y = 0; y < puzzleSize.y; ++y)
            {
                if (cookPuzzles[x, y].GetItem() == null)
                {
                    cookPuzzles[x, y].SetRandomItem();
                    print("is null >> set random Item");
                }
                else
                    print("not null");
            }
        }
    }

    public bool CheckCorrectedPuzzle(List<CookPuzzle> _list)
    {
        int correct = 0;

        for (int i = 0; i < correctedItemID.Count; ++i)
        {
            if (_list[i].item.id == correctedItemID[i])
            {
                ++correct;
            }
        }

        return correct == correctedItemID.Count;

    }

}
