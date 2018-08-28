using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Monster")]
    public static void CreateMonsterAssetFile()
    {
        Monster asset = CustomAssetUtility.CreateAsset<Monster>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "Monster";
        EditorUtility.SetDirty(asset);        
    }
    
}