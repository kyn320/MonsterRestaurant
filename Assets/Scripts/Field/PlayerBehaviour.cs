﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [HideInInspector]
    public Animator ani;

    public float moveVelocity;

    public GameObject rendererObject;

    private void Awake()
    {
        ani = rendererObject.GetComponent<Animator>();
    }



}
