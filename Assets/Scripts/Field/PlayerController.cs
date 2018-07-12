using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody ri;

    float h, v;

    public float jumpPower;
    public float moveSpeed;

    public bool isBattle = false;

    PlayerActionChecker actionChecker;

	// Use this for initialization
	void Start () {
        ri = GetComponent<Rigidbody>();
        actionChecker = transform.GetComponentInChildren<PlayerActionChecker>();
	}
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        ri.velocity = new Vector3(h * moveSpeed, ri.velocity.y,v * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
            ri.velocity = new Vector3(ri.velocity.x,jumpPower,ri.velocity.z);

        if (Input.GetKeyDown(KeyCode.Z)) {
            //action
            Action();
        }
	}

    void Action() {
        if (isBattle)
        {

        }
        else {
            if (actionChecker.IsAround()) {
               print( actionChecker.NearObject());
            }
        }
    }


}

