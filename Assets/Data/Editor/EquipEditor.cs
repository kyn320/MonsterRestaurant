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
[CustomEditor(typeof(Equip))]
public class EquipEditor : BaseGoogleEditor<Equip>
{	    
	protected SerializedProperty fileProp;

	 public override void OnEnable()
    {
        Equip t = (Equip)target;
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
        Equip targetData = target as Equip;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<EquipData>(targetData.WorksheetName) ?? db.CreateTable<EquipData>(targetData.WorksheetName);
        
        List<EquipData> myDataList = new List<EquipData>();
        
        var all = table.FindAll(targetData.FilePath);
        foreach(var elem in all)
        {
            EquipData data = new EquipData();
            
            data = Cloner.DeepCopy<EquipData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
