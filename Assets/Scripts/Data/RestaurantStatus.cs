using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RestaurantStatus
{
    //스테미너
    public int sp;
    //레벨
    public int level;
    //평판
    public int repute;
    //요리 대성공 확률
    public float perfectCookPercent;
    //기본 제공 레시피 요리 가격 변화량
    public int basicRecipePrice;
    //요리 판매 경험치 변화량
    public int cookExp;
    //레시피 경험치 변화량
    public int recipeExp;
    //레시피 대성공 시 금액 변화량
    public int perfectRecipePrice;


}
