using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Character _character;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _character.Attack();
        }
        if (_character.isAttacking)
        {
            if (other.tag == "Enemy" && _character.isDamage == false || other.tag == "Player" && _character.isDamage == false)
            {
                other.gameObject.GetComponent<Character>().AdjustedHealth(-_character._damage);
                _character.attackTime = _character.attackReset;
                _character.isDamage = true;
            }
        }
    }
}
