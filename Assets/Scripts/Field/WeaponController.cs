using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public EquipItem item;

    public bool isAttack = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttack = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAttack)
            return;

        if (other.gameObject.CompareTag("Monster"))
        {
            print("attack");
            other.gameObject.GetComponent<MonsterBehaviour>().Damage(1);
        }

    }

}
