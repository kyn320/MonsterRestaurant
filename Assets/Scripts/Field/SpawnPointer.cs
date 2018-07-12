using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointer : MonoBehaviour
{
    public SpawnPointType type;

    public Vector3 size = Vector3.one;

    public float radius = 1f;

    public int spawnCount = 1;

    private void OnDrawGizmos()
    {
        switch (type)
        {
            case SpawnPointType.Box:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(transform.position, size);
                break;
            case SpawnPointType.Circle:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, radius);
                break;
            default:
                break;
        }
    }

    public Vector3 GetPosition()
    {

        Vector3 pos;

        switch (type)
        {
            case SpawnPointType.Box:
                pos.x = Random.Range(transform.position.x - size.x * 0.5f, transform.position.x + size.x * 0.5f);
                pos.y = transform.position.y;//Random.Range(transform.position.y - size.y * 0.5f, transform.position.y + size.y * 0.5f);
                pos.z = Random.Range(transform.position.z - size.z * 0.5f, transform.position.z + size.z * 0.5f);
                return pos;
            case SpawnPointType.Circle:
                pos = transform.position + Random.insideUnitSphere * radius;
                pos.y = transform.position.y;
                return pos;
            default:
                return Vector3.zero;
        }
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }

}

[System.Serializable]
public enum SpawnPointType
{
    Box,
    Circle
}
