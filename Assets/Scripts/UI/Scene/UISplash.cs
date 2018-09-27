using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISplash : MonoBehaviour
{

    public float viewTime = 5f;

    public float exitTime = 3f;

    public Image viewImage;

    private void Start()
    {
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        float timer = viewTime;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        timer = exitTime;

        while (timer > 0)
        {
            Color color = viewImage.color;
            color.a -= 0.1f / exitTime;
            viewImage.color = color;
            timer -= Time.deltaTime;
            yield return null;
        }

        SceneLoadManager.Instance.Load("Title");

    }

}
