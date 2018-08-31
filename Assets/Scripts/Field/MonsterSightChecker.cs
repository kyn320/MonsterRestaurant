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
        monsterBehaviour.SetDestination(SetTarget());

        sphereCollider.radius *= 2f;
    }

    public void SightExit()
    {
        monsterBehaviour.SetDestination(null);
        sphereCollider.radius *= 0.5f;
    }

}
