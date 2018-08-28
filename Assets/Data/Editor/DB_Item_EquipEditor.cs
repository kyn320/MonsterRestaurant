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
[CustomEditor(typeof(DB_Item_Equip))]
public class DB_Item_EquipEditor : BaseGoogleEditor<DB_Item_Equip>
{	    
	protected SerializedProperty fileProp;

	 public override void OnEnable()
    {
        DB_Item_Equip t = (DB_Item_Equip)target;
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
        DB_Item_Equip targetData = target as DB_Item_Equip;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<DB_Item_EquipData>(targetData.WorksheetName) ?? db.CreateTable<DB_Item_EquipData>(targetData.WorksheetName);
        
        List<DB_Item_EquipData> myDataList = new List<DB_Item_EquipData>();
        
        var all = table.FindAll(targetData.FilePath);
        foreach(var elem in all)
        {
            DB_Item_EquipData data = new DB_Item_EquipData();
            
            data = Cloner.DeepCopy<DB_Item_EquipData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
