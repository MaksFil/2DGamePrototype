using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Character _character;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Player.isAttacking)
        {
            Debug.Log("+++");
            if (other.tag == "Enemy" && Player.isDamage == false)
            {
                Debug.Log("Damage was dealt!");
                other.gameObject.GetComponent<Character>().AdjustedHealth(-_character._damage);
                Player.isDamage = true;

            }
        }
    }
}
