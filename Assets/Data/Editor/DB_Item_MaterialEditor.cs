using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(DB_Item_Material))]
public class DB_Item_MaterialEditor : BaseGoogleEditor<DB_Item_Material>
{
    protected SerializedProperty fileProp;

    public override void OnEnable()
    {
        DB_Item_Material t = (DB_Item_Material)target;
        targetObject = new SerializedObject(t);

        spreadsheetProp = targetObject.FindProperty("SheetName");
        if (spreadsheetProp == null)
            Debug.LogError("Failed to find 'SheetName' property.");

        worksheetProp = targetObject.FindProperty("WorksheetName");
        if (worksheetProp == null)
            Debug.LogError("Failed to find 'WorksheetName' property.");

        fileProp = targetObject.FindProperty("FilePath");
        if (fileProp == null)
            Debug.LogError("Failed to find 'FilePath' member field.");

        serializedData = targetObject.FindProperty("dataArray");
        if (serializedData == null)
            Debug.LogError("Failed to find 'dataArray' member field.");
    }


    protected override void DrawInspector(bool useGUIStyle = true)
    {
        // Draw 'spreadsheet' and 'worksheet' name.
        EditorGUILayout.TextField(spreadsheetProp.name, spreadsheetProp.stringValue);
        EditorGUILayout.TextField(worksheetProp.name, worksheetProp.stringValue);
        EditorGUILayout.TextField(fileProp.name, fileProp.stringValue);

        // Draw properties of the data class.
        if (useGUIStyle && !isGUISkinInitialized)
        {
            isGUISkinInitialized = true;
            InitGUIStyle();
        }

        if (useGUIStyle)
            GUIHelper.DrawSerializedProperty(serializedData, box);
        else
            GUIHelper.DrawSerializedProperty(serializedData);
    }

    public override bool Load()
    {
        DB_Item_Material targetData = target as DB_Item_Material;

        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);

        if (db == null)
        {
            Debug.LogErrorFormat(targetData.SheetName + " DB is null");
            return false;
        }

        var table = db.GetTable<DB_Item_MaterialData>(targetData.WorksheetName) ?? db.CreateTable<DB_Item_MaterialData>(targetData.WorksheetName);

        List<DB_Item_MaterialData> myDataList = new List<DB_Item_MaterialData>();

        var all = table.FindAll(targetData.FilePath);
        foreach (var elem in all)
        {
            DB_Item_MaterialData data = new DB_Item_MaterialData();
            data = Cloner.DeepCopy<DB_Item_MaterialData>(elem.Element);
            myDataList.Add(data);
        }

        targetData.dataArray = myDataList.ToArray();

        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();

        return true;
    }
}
