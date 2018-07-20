using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField]
    Monster monster;

    float hp = 0;

    NavMeshAgent agent;
    Rigidbody ri;

    public float moveSpeed = 5f;
    public float stopDistance;

    public Transform target;

    public bool isMove = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ri = GetComponent<Rigidbody>();
        FieldManager.Instance.monsterNavMeshAction += Move;
        hp = monster.status.HP;
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

    public void Damage(int _damage)
    {
        hp -= _damage;
        KnockBack(25f);
    }

    public void KnockBack(float _power)
    {
        ri.AddForce(-transform.forward * _power, ForceMode.Impulse);
    }

}
