using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class ItemData
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
  
}