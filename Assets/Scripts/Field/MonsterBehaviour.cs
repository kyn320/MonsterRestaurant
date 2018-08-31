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

    private void Update()
    {
        if (!agent.isStopped)
            animator.SetFloat("Move", 1);
        else
            animator.SetFloat("Move", 0);

        print(gameObject.name + " / isStopped = " + agent.isStopped);
    }

    public void UpdateDestination(Transform _target) {
        if (target != null) {

        }
    }

    IEnumerator UpdateState()
    {
        while (true)
        {

            switch (state)
            {
                case MonsterState.Idle:

                    break;
                case MonsterState.Walk:

                    break;
                case MonsterState.Attack:

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
    Walk,
    Attack,
    Die
}