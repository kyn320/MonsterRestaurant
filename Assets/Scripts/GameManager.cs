using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float time;
    public bool isNight;

    private void Update()
    {
        time += Time.deltaTime;
    }

}
