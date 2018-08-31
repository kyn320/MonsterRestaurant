using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    [SerializeField]
    ItemData item;
    [SerializeField]
    RecipeData recipe;

    SpriteRenderer spriteRenderer;

    float sinHeight = 0.25f;

    bool isWait = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(int _id, Vector3 _pos)
    {
        if (_id >= 150)
        {
            recipe = RecipeDB.Instance.FindItem(_id);
            spriteRenderer.sprite = recipe.Icon;
        }
        else
        {
            item = ItemDB.Instance.FindItem(_id);
            spriteRenderer.sprite = item.Icon;
        }

        isWait = false;
        moveMent = StartCoroutine(DropMove(_pos));

    }

    public void GetItem(Transform _target) {
        if (!isWait)
            return;

        isWait = false;
        StartCoroutine(DragMove(_target));
    }

    Coroutine moveMent = null;

    IEnumerator DropMove(Vector3 _pos) {
        float speed = 1f;
        while ((_pos - transform.position).sqrMagnitude > 0.2f)
        {
            transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime * speed);
            speed += Time.deltaTime * 20f;
            yield return null;
        }
        isWait = true;
        moveMent = StartCoroutine(WaitMove());
    }

    IEnumerator WaitMove()
    {
        while (isWait)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * Mathf.Sin(Time.time) * sinHeight, Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator DragMove(Transform _target)
    {
        float speed = 1f;
        while ((_target.position - transform.position).sqrMagnitude > 0.3f)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * speed);
            speed += Time.deltaTime * 20f;
            yield return null;
        }

        moveMent = null;
        gameObject.SetActive(false);
    }

}
