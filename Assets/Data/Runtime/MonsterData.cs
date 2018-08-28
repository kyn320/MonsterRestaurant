using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class MonsterData
{
  [SerializeField]
  string name;
  public string Name { get {return name; } set { name = value;} }
  
  [SerializeField]
  int id;
  public int ID { get {return id; } set { id = value;} }
  
  [SerializeField]
  int minatk;
  public int Minatk { get {return minatk; } set { minatk = value;} }
  
  [SerializeField]
  int maxatk;
  public int Maxatk { get {return maxatk; } set { maxatk = value;} }
  
  [SerializeField]
  int speed;
  public int Speed { get {return speed; } set { speed = value;} }
  
  [SerializeField]
  int hp;
  public int Hp { get {return hp; } set { hp = value;} }
  
  [SerializeField]
  int def;
  public int Def { get {return def; } set { def = value;} }
  
  [SerializeField]
  int exp;
  public int Exp { get {return exp; } set { exp = value;} }
  
  [SerializeField]
  string droppercent;
  public string Droppercent { get {return droppercent; } set { droppercent = value;} }
  
  [SerializeField]
  string dropitemid;
  public string Dropitemid { get {return dropitemid; } set { dropitemid = value;} }
  
  [SerializeField]
  int mindrop;
  public int Mindrop { get {return mindrop; } set { mindrop = value;} }
  
  [SerializeField]
  int maxdrop;
  public int Maxdrop { get {return maxdrop; } set { maxdrop = value;} }
  
  [SerializeField]
  int mingold;
  public int Mingold { get {return mingold; } set { mingold = value;} }
  
  [SerializeField]
  int maxgold;
  public int Maxgold { get {return maxgold; } set { maxgold = value;} }
  
  [SerializeField]
  bool isfrist;
  public bool Isfrist { get {return isfrist; } set { isfrist = value;} }
  
  [SerializeField]
  float sight;
  public float Sight { get {return sight; } set { sight = value;} }
  
  [SerializeField]
  AttackType attacktype;
  public AttackType ATTACKTYPE { get {return attacktype; } set { attacktype = value;} }
  
}