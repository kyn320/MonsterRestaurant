using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour {

    PlayerBehaviour playerBehaviour;

    [HideInInspector]
    public Animator ani;

    public GameObject rendererObject;

    private void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
        ani = rendererObject.GetComponent<Animator>();
    }

    private void Update()
    {
        ani.SetFloat("Move", playerBehaviour.moveVelocity);
    }

}
