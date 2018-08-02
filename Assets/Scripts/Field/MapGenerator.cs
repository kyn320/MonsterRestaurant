using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{

    public Vector3 mapSize;
    public Vector3 tileSize;

    public float yOffset = 0.1f;

    public int waterDeep = -1;

    public List<GameObject> tileList;

    public GameObject folder;

    public float amp = 10f;
    public float freq = 10f;
    public FastNoise.NoiseType noiseType;
    public FastNoise.Interp noiseInterp;
    public Vector3 noiseOffeset;

    public GameObject walkable, notWalkable;

    public void Generate()
    {
        folder = new GameObject("Generate World");

        walkable = new GameObject("Walkable");
        GameObject walkalbeCubeFolder = new GameObject("Tile Maps");
        notWalkable = new GameObject("NotWalkable");
        GameObject notWalkalbeCubeFolder = new GameObject("Tile Maps");

        walkable.transform.parent = folder.transform;
        notWalkable.transform.parent = folder.transform;

        walkalbeCubeFolder.transform.parent = walkable.transform;
        notWalkalbeCubeFolder.transform.parent = notWalkable.transform;

        Vector3 startPos = Vector3.zero;
        startPos.x = folder.transform.position.x - mapSize.x * 0.5f * tileSize.x + 0.5f * tileSize.x;
        startPos.z = folder.transform.position.z - mapSize.z * 0.5f * tileSize.z + 0.5f * tileSize.z;
        startPos.y = -tileSize.y * 0.5f;


        for (int x = 0; x < mapSize.x; ++x)
        {
            for (int z = 0; z < mapSize.z; ++z)
            {
                FastNoise noise = new FastNoise();
                noise.SetNoiseType(noiseType);
                noise.SetFrequency(freq);
                noise.SetGradientPerturbAmp(amp);
                noise.SetInterp(noiseInterp);

                float yPos = noise.GetNoise(x + noiseOffeset.x, noiseOffeset.y, z + noiseOffeset.z) * 10f * tileSize.y;

                yPos -= yPos % tileSize.y;
                yPos /= tileSize.y;

                float y = yPos * 0.5f * yOffset;

                GameObject g;
                if (yPos > waterDeep)
                {
                    g = Instantiate(tileList[0], walkable.transform);
                    g.transform.parent = walkalbeCubeFolder.transform;
                }
                else
                {
                    g = Instantiate(tileList[1], notWalkable.transform);
                    g.transform.parent = notWalkalbeCubeFolder.transform;
                }

                g.transform.position = startPos + Vector3.right * x * tileSize.x + Vector3.forward * z * tileSize.z + Vector3.up * y;
            }
        }

    }


    public void SetQuater()
    {
        folder.transform.rotation = Quaternion.Euler(0, 45, 0);
    }

    public void BakeNavMesh()
    {
        walkable.AddComponent<NavMeshSurface>();
        walkable.GetComponent<NavMeshSurface>().collectObjects = CollectObjects.Children;
        walkable.GetComponent<NavMeshSurface>().defaultArea = 0;
        walkable.GetComponent<NavMeshSurface>().BuildNavMesh();

        notWalkable.AddComponent<NavMeshSurface>();
        notWalkable.GetComponent<NavMeshSurface>().collectObjects = CollectObjects.Children;
        notWalkable.GetComponent<NavMeshSurface>().defaultArea = 1;
        notWalkable.GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    public void TileListClear()
    {
        DestroyImmediate(folder);
    }

}
