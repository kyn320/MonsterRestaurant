using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionChecker : MonoBehaviour
{
    public LayerMask layerMask;

    public List<GameObject> objectList;

    private void OnTriggerEnter(Collider _col)
    {
        if (layerMask.value.Equals(1 << _col.gameObject.layer))
        {
            objectList.Add(_col.gameObject);
        }
    }

    private void OnTriggerExit(Collider _col)
    {
        if (layerMask.value.Equals(1 << _col.gameObject.layer))
        {
            objectList.Remove(_col.gameObject);
        }
    }

    public bool IsAround()
    {
        return objectList.Count > 0;
    }

    public GameObject NearObject()
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

}
