using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FieldStatus  {
    //체력
    public int HP;
    //마나
    public int MP;
    //스테미너
    public int SP;
    //레벨
    public int Level;
    //경험치
    public int EXP;
    //최소 공격력
    public int MinAtk;
    //최대 공격력
    public int MaxAtk;
    //방어력
    public int Def;
    //회피도
    public int Dodge;
    //크리티컬
    public int Critical;
    //이동 속도
    public float MoveSpeed;
    //채집 시간 변화량
    public float GatheringTime;
    //최소 아이템 획득량
    public int MinItemDrop;
    //최대 아이템 획득량
    public int MaxItemDrop;
    //포획 성공 확률
    public float CapturePercent;

}
