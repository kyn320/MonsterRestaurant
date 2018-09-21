using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerBehaviour playerBehaviour;
    Rigidbody ri;

    [SerializeField]
    float h, v;

    public float jumpPower;
    public float rotationSpeed;
    public float moveSpeed;

    public int attackCombo;

    public bool isInput = false;
    public bool isBattle = false;

    PlayerActionChecker actionChecker;

    [SerializeField]
    Vector3 dir = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        ri = GetComponent<Rigidbody>();
        playerBehaviour = GetComponent<PlayerBehaviour>();
        actionChecker = transform.GetComponentInChildren<PlayerActionChecker>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (isInput)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
#endif


        if (Mathf.Abs(h) > 0.2f || Mathf.Abs(v) > 0.2f)
        {
            dir = new Vector3(h, dir.y, v);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);

        ri.velocity = new Vector3(h * moveSpeed, ri.velocity.y, v * moveSpeed);
        playerBehaviour.ani.SetFloat("Move", ri.velocity.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
            ri.velocity = new Vector3(ri.velocity.x, jumpPower, ri.velocity.z);

        if (isInput && Input.GetKeyDown(KeyCode.Z))
        {
            //action
            Action();
        }
    }

    void Action()
    {
        if (isBattle)
        {
            ++attackCombo;

            if (attackCombo == 3)
                attackCombo = 1;

            playerBehaviour.ani.SetInteger("AttackCombo", attackCombo);
            playerBehaviour.ani.SetTrigger("Attack");

        }
        else
        {
            if (actionChecker.IsAround())
            {
                playerBehaviour.ani.SetBool("Search", true);
                print(actionChecker.NearObject());
            }
        }
    }

    public void SetAxis(Vector2 _axis)
    {
        h = _axis.x;
        v = _axis.y;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("DropItem"))
        {
            _other.gameObject.GetComponent<DropItem>().GetItem(transform);
        }
    }

}

