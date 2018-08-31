using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField]
    int monsterID;

    [SerializeField]
    MonsterData monster;

    public MonsterState state;

    [SerializeField]
    float hp = 0;

    [SerializeField]
    float stateChangeTime = 0f;

    NavMeshAgent agent;
    Rigidbody ri;
    Animator animator;

    public float moveSpeed = 5f;
    public float stopDistance;

    public Transform target;

    MonsterSightChecker sightChecker;
    Dropper dropper;

    private void Awake()
    {
        sightChecker = transform.GetComponentInChildren<MonsterSightChecker>();
        agent = GetComponent<NavMeshAgent>();
        ri = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        dropper = GetComponent<Dropper>();
        FieldManager.Instance.monsterNavMeshAction += InitMove;
    }

    private void Start()
    {
        monster = MonsterDB.Instance.FindItem(monsterID);

        dropper.SetDropList(monster.Dropitemid, monster.Droppercent,
            monster.Mindrop, monster.Maxdrop,
            monster.Mingold, monster.Maxgold);

        sightChecker.SetSight(monster.Sight + 2f);
        hp = monster.Hp;

        StartCoroutine(UpdateState());

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

    }

    private void FixedUpdate()
    {
        ri.velocity = agent.velocity;
    }

    public void SetDestination(Transform _target)
    {
        target = _target;

        if (target == null)
        {
            agent.SetDestination(RandomPos());
        }
        else
            agent.SetDestination(_target.position);

        ChangeState(MonsterState.Move);
    }

    private bool CheckReachedDestination()
    {
        return (agent.destination - transform.position).sqrMagnitude <= (agent.stoppingDistance * agent.stoppingDistance);
    }

    public void ChangeRandomState(float _changeTime = 0f)
    {
        state = (MonsterState)Random.Range(0, 3);
        switch (state)
        {
            case MonsterState.Idle:
                animator.SetFloat("Move", 0);
                stateChangeTime = Random.Range(1f, 5f);
                break;
            case MonsterState.Move:
                agent.isStopped = false;
                animator.SetFloat("Move", 1);
                agent.SetDestination(RandomPos());
                break;
            case MonsterState.Attack:
                animator.SetInteger("Attack", 1);
                break;
            case MonsterState.Die:
                animator.SetBool("Die", true);
                break;
        }
    }

    public void ChangeState(MonsterState _state, float _changeTime = 0f)
    {
        state = _state;

        switch (state)
        {
            case MonsterState.Idle:
                animator.SetFloat("Move", 0);
                stateChangeTime = Random.Range(1f, 5f);
                break;
            case MonsterState.Move:
                agent.isStopped = false;
                animator.SetFloat("Move", 1);
                break;
            case MonsterState.Attack:
                animator.SetInteger("Attack", 1);
                break;
            case MonsterState.Die:
                animator.SetBool("Die", true);
                break;
        }
    }

    IEnumerator UpdateState()
    {
        while (true)
        {
            switch (state)
            {
                case MonsterState.Idle:
                    stateChangeTime -= 0.1f;
                    if (stateChangeTime <= 0)
                        ChangeRandomState();
                    break;
                case MonsterState.Move:
                    if (target != null)
                        agent.SetDestination(target.position);

                    if (CheckReachedDestination())
                    {
                        agent.isStopped = true;
                        if (target != null)
                        {
                            ChangeState(MonsterState.Attack);
                        }
                        else
                        {
                            ChangeRandomState();
                        }
                    }
                    break;
                case MonsterState.Attack:
                    if (!CheckReachedDestination())
                    {
                        SetDestination(target);
                    }
                    break;
                case MonsterState.Die:
                    break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Damage(int _damage)
    {
        hp -= _damage;
        KnockBack(25f);

        if (hp <= 0)
        {
            print("drop");
            dropper.Drop();
        }
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

[System.Serializable]
public enum MonsterState
{
    Idle,
    Move,
    Attack,
    Die
}