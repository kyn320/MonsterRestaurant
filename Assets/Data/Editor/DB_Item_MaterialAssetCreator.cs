using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/DB_Item_Material")]
    public static void CreateDB_Item_MaterialAssetFile()
    {
        DB_Item_Material asset = CustomAssetUtility.CreateAsset<DB_Item_Material>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "DB_Item_Material";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}