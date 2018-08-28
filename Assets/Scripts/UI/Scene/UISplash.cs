using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISplash : MonoBehaviour {


    private void Start()
    {
        SceneLoadManager.Instance.Load("Title");
    }
}
