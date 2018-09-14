using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzleManager : Singleton<CookPuzzleManager>
{
    public GameObject slotPrefab;

    public Vector2 slotSize;
    public Vector2 margin;

    public Vector2Int puzzleSize;

    public RecipeData recipe;

    CookPuzzle[,] cookPuzzles;

    List<int> correctedItemID = new List<int>();

    public List<int> materialIDList;

    [SerializeField]
    UIRestaurant uIRestaurant;

    private void Start()
    {
        recipe = RecipeDB.Instance.FindItem(150);

        SetItemList();
        CreatePuzzleSlot();
        SetRecipePuzzle();
        SetRandomEmptyPuzzle();

        uIRestaurant.combinationView.CreateCombination(recipe.Icon, materialIDList);
    }

    public void SetItemList()
    {
        string[] combination = recipe.Combination.Split('|');

        for (int i = 0; i < combination.Length; ++i)
        {
            string[] data = combination[i].Split('/');

            int id = int.Parse(data[0]);
            int value = int.Parse(data[1]);

            for (int j = 0; j < value; ++j)
            {
                materialIDList.Add(id);
            }
        }
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
        for (int i = 0; i < materialIDList.Count; ++i)
        {
            Vector2Int randPos;
            int loopCount = 0;
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
                ++loopCount;
                if (loopCount > 100)
                {
                    Debug.LogError("퍼즐의 위치를 결정할 수 없습니다.");
                    break;
                }
            }
            correctedItemID.Add(materialIDList[i]);
            cookPuzzles[randPos.x, randPos.y].SetItem(ItemDB.Instance.FindItem(materialIDList[i]));
            startPos = randPos;
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
                }
            }
        }
    }

    public void ResetCombination()
    {
        uIRestaurant.combinationView.ResetIndex();
    }

    public bool CheckCorrectedPuzzleSlot(int _index, CookPuzzle _puzzle)
    {
        if (correctedItemID[_index] == _puzzle.item.ID)
        {
            uIRestaurant.combinationView.UpdateIndex();
            return true;
        }
        else
        {
            uIRestaurant.combinationView.ResetIndex();
            return false;
        }
    }

    public bool CheckCorrectedPuzzle(List<CookPuzzle> _list)
    {
        if (_list.Count != correctedItemID.Count)
            return false;

        int correct = 0;

        for (int i = 0; i < correctedItemID.Count; ++i)
        {
            if (_list[i].item.ID == correctedItemID[i])
            {
                ++correct;
            }
        }

        return correct == correctedItemID.Count;

    }

}
