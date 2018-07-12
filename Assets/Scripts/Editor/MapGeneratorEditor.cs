using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapGenerator mapGenerator = target as MapGenerator;

        if (GUILayout.Button("Generate"))
        {
            if (mapGenerator)
            {
                mapGenerator.Generate();
            }
        }

        if (GUILayout.Button("Clear"))
        {
            if (mapGenerator)
            {
                mapGenerator.TileListClear();
            }
        }

    }
}
