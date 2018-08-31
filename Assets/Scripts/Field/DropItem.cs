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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(int _id)
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


    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * Mathf.Sin(Time.time) * sinHeight, Time.deltaTime);
    }


}
