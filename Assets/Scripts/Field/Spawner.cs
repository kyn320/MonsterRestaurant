using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public SpawnPointer[] spawnPoints;

    public GameObject spawnObjectPrefab;

    public bool isObstacle = false;

    public LayerMask layerMask;

    GameObject folder;

    public bool isAutoSpawn = true;

    List<GameObject> objectList = new List<GameObject>();

    private void Awake()
    {
        if (isAutoSpawn)
        {
            SpawnManager.Instance.AddSpawnList(this);
            SpawnManager.Instance.spawnAction += Spawn;

            print("spawn event add");
        }

    }

    public void Spawn()
    {
        print(spawnObjectPrefab.name + " is spawn");
        folder = new GameObject(spawnObjectPrefab.name);


        if (isObstacle)
            folder.transform.parent = FieldManager.Instance.GetWalkable().transform;
        else
            folder.transform.parent = FieldManager.Instance.GetNotWalkable().transform;



        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            int spawnCount = spawnPoints[i].GetSpawnCount();
            for (int k = 0; k < spawnCount; ++k)
            {
                Vector3 pos = Vector3.zero;

                int loopCount = 100;

                while (loopCount > 0)
                {
                    pos = spawnPoints[i].GetPosition();
                    RaycastHit hit;
                    Debug.DrawRay(pos + Vector3.up * 1f, Vector3.down * 30f, Color.red, 1f);
                    if (Physics.Raycast(pos + Vector3.up * 1f, Vector3.down, out hit, 30f, layerMask))
                    {
                        break;
                    }
                    --loopCount;
                }

                if (loopCount < 1)
                    print("LoopOut");

                GameObject spawnObject = Instantiate(spawnObjectPrefab, pos, spawnObjectPrefab.transform.localRotation);
                objectList.Add(spawnObject);
                spawnObject.transform.parent = folder.transform;
            }
        }
    }

    public void AddSpawnPointer()
    {
        GameObject g = new GameObject("SpawnPointer");
        g.transform.parent = transform;
        g.AddComponent<SpawnPointer>();
    }

    public void GetSpawnPointer()
    {
        spawnPoints = transform.GetComponentsInChildren<SpawnPointer>();
    }

    public void RemoveSpawnObjects()
    {
        DestroyImmediate(folder);
        objectList.Clear();
    }

}
