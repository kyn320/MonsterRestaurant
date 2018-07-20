using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzleManager : MonoBehaviour {

    public GameObject slotPrefab;

    public Vector2 slotSize;
    public Vector2 margin;

    public Vector2Int puzzleSize;

    private void Start()
    {
        CreatePuzzleSlot();
    }

    public void CreatePuzzleSlot() {
        Vector2 startPos;
        startPos.x = -(puzzleSize.x - 1) * (slotSize.x + margin.x) * 0.5f;
        startPos.y = -(puzzleSize.y - 1) * (slotSize.y + margin.y) * 0.5f;

        for (int x = 0; x < puzzleSize.x; ++x) {
            for (int y = 0; y < puzzleSize.y; ++y) {
                GameObject g = Instantiate(slotPrefab, transform);
                g.transform.localPosition = new Vector3(startPos.x + x * (slotSize.x+ margin.x), startPos.y + y * (slotSize.y + margin.y));

            }
        }


    }


}
