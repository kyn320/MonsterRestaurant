using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITargetFollow : MonoBehaviour
{
    public Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        transform.position = Camera.main.WorldToScreenPoint(target.position);
    }

}
