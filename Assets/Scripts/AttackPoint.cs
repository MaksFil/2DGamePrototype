using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (PlayerController.isAttacking)
        {
            if (other.tag == "Enemy" && PlayerController._damage == false)
            {
                Debug.Log("Damage was dealt!");
                PlayerController._damage = true;
            }
        }
    }
}
