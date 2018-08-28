using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Item")]
    public static void CreateItemAssetFile()
    {
        Item asset = CustomAssetUtility.CreateAsset<Item>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "Item";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}