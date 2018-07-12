using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField]
    Monster monster;

    NavMeshAgent agent;

    public float moveSpeed = 5f;
    public float stopDistance;

    public Transform target;

    public bool isMove = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        FieldManager.Instance.monsterNavMeshAction += Move;
    }

    public void Move()
    {
        agent.stoppingDistance = stopDistance;
        agent.speed = moveSpeed;
        agent.destination = target.position;
        isMove = true;
    }

    private void LateUpdate()
    {
        if (!isMove)
            return;

        if (target != null)
            agent.destination = target.position;
    }

}
