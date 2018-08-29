using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzleContoller : MonoBehaviour
{
    CookPuzzleManager manager;

    public List<CookPuzzle> selectPuzzles;

    LineRenderer lineRenderer;

    bool isMouseDown = false;
    CookPuzzle oldPuzzle;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        manager = GetComponent<CookPuzzleManager>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            if (manager.CheckCorrectedPuzzle(selectPuzzles))
            {
                print("is correct");
            }
            else
            {
                print("not correct");
            }

            ResetPuzzle();
        }

        SelectPuzzle();

    }

    void SelectPuzzle()
    {
        if (!isMouseDown)
            return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 20f);
        if (hit)
        {

            CookPuzzle puzzle = hit.transform.GetComponent<CookPuzzle>();

            if (!puzzle.GetSelect() && puzzle.IsAround(oldPuzzle))
            {
                puzzle.SetSelect(true);
                selectPuzzles.Add(puzzle);
                manager.CheckCorrectedPuzzleSlot(selectPuzzles.Count - 1, puzzle);
                ++lineRenderer.positionCount;
                lineRenderer.SetPosition(selectPuzzles.Count - 1, puzzle.transform.position);
                oldPuzzle = puzzle;
            }
        }
    }

    void ResetPuzzle()
    {
        for (int i = 0; i < selectPuzzles.Count; ++i)
        {
            selectPuzzles[i].SetSelect(false);
        }
        oldPuzzle = null;
        selectPuzzles.Clear();
        lineRenderer.positionCount = 0;
        manager.ResetCombination();
    }

}


