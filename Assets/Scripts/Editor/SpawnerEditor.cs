using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Spawner spawner = target as Spawner;

        if (GUILayout.Button("Add SpawnPointer"))
        {
            if (spawner)
            {
                spawner.AddSpawnPointer();
            }
        }

        if (GUILayout.Button("Get SpawnPointer"))
        {
            if (spawner)
            {
                spawner.GetSpawnPointer();
            }
        }

        if (GUILayout.Button("Spawn"))
        {
            if (spawner)
            {
                spawner.Spawn();
            }
        }

        if (GUILayout.Button("RemoveSpawnObjects"))
        {
            if (spawner)
            {
                spawner.RemoveSpawnObjects();
            }
        }

    }

}
