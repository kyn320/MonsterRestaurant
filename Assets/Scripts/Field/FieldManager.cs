using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldManager : Singleton<FieldManager>
{
    GameObject walkable, notWalkable;

    public FieldCategory category;

    public UnityAction monsterNavMeshAction;

    public UnityAction spawnAction;

    public void MonsterNavMeshAction()
    {
        if (monsterNavMeshAction != null)
            monsterNavMeshAction.Invoke();
    }

    public void SpawnAction()
    {
        if (spawnAction != null)
            spawnAction.Invoke();
    }

    public void SetArea(GameObject _walkable, GameObject _notWalkable)
    {
        walkable = _walkable;
        notWalkable = _notWalkable;
    }

    public GameObject GetWalkable() {
        return walkable;
    }

    public GameObject GetNotWalkable() {
        return notWalkable;
    }

}

[System.Serializable]
public enum FieldCategory
{

    Grass,
    Desert,
    Jungle,
    Mine

}