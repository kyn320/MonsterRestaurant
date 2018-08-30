using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : Singleton<SpawnManager>
{

    public List<Spawner> spawnerList;

    public UnityAction spawnAction;


    public void SpawnAction()
    {
        if (spawnAction != null)
        {
            spawnAction.Invoke();
        }

    }

    public void AddSpawnList(Spawner _spawner)
    {
        spawnerList.Add(_spawner);
    }

}
