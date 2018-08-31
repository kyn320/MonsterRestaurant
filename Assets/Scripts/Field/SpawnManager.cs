using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : Singleton<SpawnManager>
{

    public List<Spawner> spawnerList;

    public UnityAction bakeSpawnAction;

    public UnityAction notBakeSpawnAction;


    public void SpawnBakeAction()
    {
        if (bakeSpawnAction != null)
        {
            bakeSpawnAction.Invoke();
        }

    }

    public void SpawnNotBakeAction()
    {
        if (notBakeSpawnAction != null)
        {
            notBakeSpawnAction.Invoke();
        }

    }

    public void AddSpawnList(Spawner _spawner)
    {
        spawnerList.Add(_spawner);
    }

}
