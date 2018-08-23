using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : MonoBehaviour {

    public void OnStart() {
        SceneLoadManager.Instance.Load("WorldMap");
    }

}
