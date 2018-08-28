using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class DB_Item_EquipData
{
  [SerializeField]
  string name;
  public string Name { get {return name; } set { name = value;} }
  
  [SerializeField]
  int id;
  public int ID { get {return id; } set { id = value;} }
  
  [SerializeField]
  string context;
  public string Context { get {return context; } set { context = value;} }
  
  [SerializeField]
  Sprite icon;
  public Sprite Icon { get {return icon; } set { icon = value;} }
  
  [SerializeField]
  int atk;
  public int Atk { get {return atk; } set { atk = value;} }
  
  [SerializeField]
  int def;
  public int Def { get {return def; } set { def = value;} }
  
  [SerializeField]
  int addslot;
  public int Addslot { get {return addslot; } set { addslot = value;} }
  
  [SerializeField]
  int battlesp;
  public int Battlesp { get {return battlesp; } set { battlesp = value;} }
  
  [SerializeField]
  int gathersp;
  public int Gathersp { get {return gathersp; } set { gathersp = value;} }
  
}