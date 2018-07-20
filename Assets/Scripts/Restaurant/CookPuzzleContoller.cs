using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzleContoller : MonoBehaviour
{
    public List<CookPuzzle> selectPuzzles;

    bool isMouseDown = false;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
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

            if (!puzzle.GetSelect())
            {
                puzzle.SetSelect(true);
                selectPuzzles.Add(puzzle);
            }

        }
    }

}


