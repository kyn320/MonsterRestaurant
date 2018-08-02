using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody ri;

    float h, v;

    public float jumpPower;
    public float moveSpeed;

    public bool isBattle = false;

    PlayerActionChecker actionChecker;

    [SerializeField]
    Vector3 dir = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        ri = GetComponent<Rigidbody>();
        actionChecker = transform.GetComponentInChildren<PlayerActionChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        */

        if (Mathf.Abs(h) > 0.5f || Mathf.Abs(v) > 0.5f)
            dir = new Vector3(h, dir.y, v);

        transform.rotation = Quaternion.LookRotation(dir);

        ri.velocity = new Vector3(h * moveSpeed, ri.velocity.y, v * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
            ri.velocity = new Vector3(ri.velocity.x, jumpPower, ri.velocity.z);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //action
            Action();
        }
    }

    void Action()
    {
        if (isBattle)
        {

        }
        else
        {
            if (actionChecker.IsAround())
            {
                print(actionChecker.NearObject());
            }
        }
    }

    public void SetAxis(Vector2 _axis)
    {
        h = _axis.x;
        v = _axis.y;
    }

}

