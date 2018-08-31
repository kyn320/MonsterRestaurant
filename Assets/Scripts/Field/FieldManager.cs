using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*TODO ::

 블럭의 주변을 가져와야함
 EX) 물 주변, 특정 블럭 근처 

*/

public class FieldManager : Singleton<FieldManager>
{
    GameObject walkable, notWalkable;

    public FieldCategory category;

    public UnityAction monsterNavMeshAction;


    [SerializeField]
    MapGenerator mapGenerator;

    [SerializeField]
    SpawnManager spawnManager;
    
    private void OnEnable()
    {
        mapGenerator.SetMapCategory(ConvertFieldCategoryToString(category));
        mapGenerator.Generate();

        SetArea(mapGenerator.walkable, mapGenerator.notWalkable);

        spawnManager.SpawnBakeAction();

        mapGenerator.SetQuater();
        mapGenerator.BakeNavMesh();

        spawnManager.SpawnNotBakeAction();

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

    public static string ConvertFieldCategoryToString(FieldCategory _fieldCategory)
    {

        switch (_fieldCategory)
        {
            case FieldCategory.Grass:
                return "Grass";
            case FieldCategory.Desert:
                return "Desert";
            case FieldCategory.Jungle:
                return "Jungle";
            case FieldCategory.Mine:
                return "Mine";
            default:
                return "";
        }

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