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
[CustomEditor(typeof(DB_Monster))]
public class DB_MonsterEditor : BaseGoogleEditor<DB_Monster>
{	    
    public override bool Load()
    {        
        DB_Monster targetData = target as DB_Monster;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<DB_MonsterData>(targetData.WorksheetName) ?? db.CreateTable<DB_MonsterData>(targetData.WorksheetName);
        
        List<DB_MonsterData> myDataList = new List<DB_MonsterData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            DB_MonsterData data = new DB_MonsterData();
            
            data = Cloner.DeepCopy<DB_MonsterData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
