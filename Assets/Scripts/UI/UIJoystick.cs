using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector3 orignPos;

    public Vector3 dir;

    [SerializeField]
    float inputRadius;

    RectTransform stick, canvas;

    void Awake()
    {
        stick = transform.GetChild(0).GetComponent<RectTransform>();
        canvas = transform.root.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        inputRadius = stick.sizeDelta.x * 0.8f * canvas.localScale.x;
        orignPos = stick.transform.position;
        OnDrag(_eventData);
    }

    public void OnDrag(PointerEventData _eventData)
    {
        Vector3 pos = _eventData.position;

        dir = (pos - orignPos).normalized;

        float distance = Vector3.Distance(pos, orignPos);

        if (distance > inputRadius)
        {
            stick.transform.position = orignPos + dir * inputRadius;
        }
        else
        {
            stick.transform.position = orignPos + dir * distance;
        }

    }

    public void OnPointerUp(PointerEventData _eventData)
    {
        stick.transform.position = orignPos;
        dir = Vector3.zero;
    }

}
