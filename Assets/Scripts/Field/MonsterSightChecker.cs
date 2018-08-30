using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSightChecker : SightChecker
{
    MonsterBehaviour monsterBehaviour;

    protected override void Awake()
    {
        monsterBehaviour = transform.root.GetComponent<MonsterBehaviour>();
        base.Awake();
        enterSightEvent += SightEnter;
        exitSightEvent += SightExit;
    }

    public void SightEnter()
    {
        monsterBehaviour.target = SetTarget();
    }

    public void SightExit() {
        monsterBehaviour.target = null;
    }

}
