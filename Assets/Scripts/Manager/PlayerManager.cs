using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int fieldSP;
    public int maxFieldSP;
    public int restaurantSP;
    public int maxRestaurantSP;
    public int gold;

    public PlayerBehaviour player;
}
