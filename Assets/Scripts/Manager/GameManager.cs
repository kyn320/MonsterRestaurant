using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public bool isNight;

    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = PlayerManager.Instance;
    }

}
