using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Equip")]
    public static void CreateEquipAssetFile()
    {
        Equip asset = CustomAssetUtility.CreateAsset<Equip>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "Equip";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}