using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/DB_Item_Equip")]
    public static void CreateDB_Item_EquipAssetFile()
    {
        DB_Item_Equip asset = CustomAssetUtility.CreateAsset<DB_Item_Equip>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "DB_Item_Equip";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}