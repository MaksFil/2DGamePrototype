using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private int _direction;

    public override void Walking(int direction)
    {
        base.Walking(direction);
        if (direction > 0)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -25);
        }
        if (direction < 0)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(0, -180, 0);
            Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, 25);
        }
    }
    public override void Attack()
    {
        if (withHammer)
        {
            base.Attack();
            attackTime = attackReset;
        }

        }
    public void OnClickMoveButton(int direction)
    {
        _direction = direction;
    }

    public void OnClickJumpButton()
    {
        Jump();
    }
    public void OnClickHammerAttackButton()
    {
        Attack();
    }

    public override void Death()
    {
        Debug.Log("You death");
        _health = 100;
    }

    private void Update() 
    {
        AttackTimer();
    }
    private void FixedUpdate()
    {
        if (_direction > 0) Walking(_direction);
        else if (_direction < 0) Walking(_direction);
        else Idle();
    }
}
