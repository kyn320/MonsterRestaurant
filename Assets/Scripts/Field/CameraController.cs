using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public float lerpTime = 10f;
    public Vector3 margin;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target != null) {
            transform.position = Vector3.Lerp(transform.position,target.position + margin, Time.deltaTime * lerpTime);
        }
    }


}
