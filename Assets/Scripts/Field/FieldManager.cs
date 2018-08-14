using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*TODO ::

 블럭의 주변을 가져와야함
 EX) 물 주변, 특정 블럭 근처 

 블럭을 주변 생태계와 알맞게 적용해야함.
 EX) 물 근처 땅 블럭들은 더 짙은 색이나, 물에 젖은 색상 텍스쳐로 변경,
 물 근처 땅 블럭은 젖어있는 상태로 전환

*/

public class FieldManager : Singleton<FieldManager>
{
    GameObject walkable, notWalkable;

    public FieldCategory category;

    public UnityAction monsterNavMeshAction;

    public UnityAction spawnAction;

    [SerializeField]
    MapGenerator mapGenerator;

    private void OnEnable()
    {
        mapGenerator.Generate();

        SetArea(mapGenerator.walkable, mapGenerator.notWalkable);

        SpawnAction();

        mapGenerator.SetQuater();
        mapGenerator.BakeNavMesh();

    }

    private void Start()
    {
        MonsterNavMeshAction();
    }

    public void MonsterNavMeshAction()
    {
        if (monsterNavMeshAction != null)
            monsterNavMeshAction.Invoke();
    }

    public void SpawnAction()
    {
        if (spawnAction != null)
        {
            spawnAction.Invoke();


            print("spawn action");
        }

    }

    public void SetArea(GameObject _walkable, GameObject _notWalkable)
    {
        walkable = _walkable;
        notWalkable = _notWalkable;
    }

    public GameObject GetWalkable()
    {
        return walkable;
    }

    public GameObject GetNotWalkable()
    {
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