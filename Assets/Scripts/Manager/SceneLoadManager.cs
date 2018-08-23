using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{



    public void Load(string _name)
    {
        SceneManager.LoadScene(_name);
    }

}
