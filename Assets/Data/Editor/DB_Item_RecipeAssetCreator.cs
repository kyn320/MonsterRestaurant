using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/DB_Item_Recipe")]
    public static void CreateDB_Item_RecipeAssetFile()
    {
        DB_Item_Recipe asset = CustomAssetUtility.CreateAsset<DB_Item_Recipe>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "DB_Item_Recipe";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}