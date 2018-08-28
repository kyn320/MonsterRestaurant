using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/DB_Monster")]
    public static void CreateDB_MonsterAssetFile()
    {
        DB_Monster asset = CustomAssetUtility.CreateAsset<DB_Monster>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "DB_Monster";
        EditorUtility.SetDirty(asset);        
    }
    
}