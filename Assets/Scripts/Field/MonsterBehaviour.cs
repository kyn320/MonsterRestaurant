using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField]
    MonsterData monster;

    float hp = 0;

    NavMeshAgent agent;
    Rigidbody ri;

    public float moveSpeed = 5f;
    public float stopDistance;

    public Transform target;

    public bool isMove = false;

    MonsterSightChecker sightChecker;

    private void Awake()
    {
        sightChecker = transform.GetComponentInChildren<MonsterSightChecker>();
        agent = GetComponent<NavMeshAgent>();
        ri = GetComponent<Rigidbody>();
        FieldManager.Instance.monsterNavMeshAction += InitMove;
    }

    private void Start()
    {
        sightChecker.SetSight(monster.Sight + 2f);
        hp = monster.Hp;
    }

    public void InitMove()
    {
        if (target != null)
        {
            agent.destination = target.position;
        }
        else
        {
            agent.destination = RandomPos();
        }
        agent.stoppingDistance = stopDistance;
        agent.speed = moveSpeed;
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

    private Vector3 RandomPos()
    {
        Vector3 pos = Vector3.zero;

        int loopCount = 10;
        while (loopCount > 0)
        {

            pos = transform.position + Random.insideUnitSphere * 100f * monster.Sight;
            pos.y = transform.position.y;
            
            RaycastHit hit;
            Debug.DrawRay(pos + Vector3.up * 1f, Vector3.down * 30f, Color.blue, 5000f);
            if (Physics.Raycast(pos + Vector3.up * 1f, Vector3.down, out hit, 30f, LayerMask.GetMask("Walkable")))
            {
                return pos;
            }
            --loopCount;
        }

        return pos;
    }

}
