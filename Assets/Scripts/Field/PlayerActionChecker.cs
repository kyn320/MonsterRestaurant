using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionChecker : SightChecker
{
    //TODO :: 시야에 들어오면 채집 액션으로 변경

    PlayerBehaviour playerBehaviour;

    protected override void Awake()
    {
        playerBehaviour = transform.root.GetComponent<PlayerBehaviour>();

        base.Awake();
    }



}
