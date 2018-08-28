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
[CustomEditor(typeof(DB_Item_Recipe))]
public class DB_Item_RecipeEditor : BaseGoogleEditor<DB_Item_Recipe>
{	    
	protected SerializedProperty fileProp;

	 public override void OnEnable()
    {
        DB_Item_Recipe t = (DB_Item_Recipe)target;
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
        DB_Item_Recipe targetData = target as DB_Item_Recipe;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<DB_Item_RecipeData>(targetData.WorksheetName) ?? db.CreateTable<DB_Item_RecipeData>(targetData.WorksheetName);
        
        List<DB_Item_RecipeData> myDataList = new List<DB_Item_RecipeData>();
        
        var all = table.FindAll(targetData.FilePath);
        foreach(var elem in all)
        {
            DB_Item_RecipeData data = new DB_Item_RecipeData();
            
            data = Cloner.DeepCopy<DB_Item_RecipeData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
