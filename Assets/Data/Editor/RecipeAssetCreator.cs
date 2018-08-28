using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Recipe")]
    public static void CreateRecipeAssetFile()
    {
        Recipe asset = CustomAssetUtility.CreateAsset<Recipe>();
        asset.SheetName = "몬스터 레스토랑";
        asset.WorksheetName = "Recipe";
		asset.FilePath = "Sprites/Icon";
        EditorUtility.SetDirty(asset);        
    }
    
}