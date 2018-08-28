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
[CustomEditor(typeof(Monster))]
public class MonsterEditor : BaseGoogleEditor<Monster>
{	    
    public override bool Load()
    {        
        Monster targetData = target as Monster;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<MonsterData>(targetData.WorksheetName) ?? db.CreateTable<MonsterData>(targetData.WorksheetName);
        
        List<MonsterData> myDataList = new List<MonsterData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            MonsterData data = new MonsterData();
            
            data = Cloner.DeepCopy<MonsterData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
