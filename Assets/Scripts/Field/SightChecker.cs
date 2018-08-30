using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SightChecker : MonoBehaviour
{

    [Tooltip("Radius 기준입니다.")]
    public float sightSize;

    public LayerMask layerMask;

    public List<GameObject> objectList;

    public UnityAction enterSightEvent;
    public UnityAction exitSightEvent;

    [SerializeField]
    SphereCollider sphereCollider;

    protected virtual void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }
    
    public void SetSight(float _sight)
    {
        sightSize = _sight;
        sphereCollider.radius = sightSize;
    }

    protected virtual void OnTriggerEnter(Collider _col)
    {
        if (layerMask.value.Equals(1 << _col.gameObject.layer))
        {
            objectList.Add(_col.gameObject);

            if (enterSightEvent != null)
            {
                enterSightEvent.Invoke();
            }
        }
    }

    protected virtual void OnTriggerExit(Collider _col)
    {
        if (layerMask.value.Equals(1 << _col.gameObject.layer))
        {
            objectList.Remove(_col.gameObject);

            if (exitSightEvent != null)
            {
                exitSightEvent.Invoke();
            }
        }
    }

    public virtual bool IsAround()
    {
        return objectList.Count > 0;
    }

    public virtual GameObject NearObject()
    {
        int index = -1;
        float distance = 999f;


        for (int i = 0; i < objectList.Count; ++i)
        {
            float sqr = (objectList[i].transform.position - transform.position).sqrMagnitude;
            if (sqr < distance)
            {
                distance = sqr;
                index = i;
            }
        }

        return objectList[index];
    }

    public Transform SetTarget()
    {
        return NearObject().transform;
    }

}
