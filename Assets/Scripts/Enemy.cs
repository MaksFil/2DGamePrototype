using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private int _direction;

    public override void Attack()
    {
        if (withHammer && attackTime <= 0) base.Attack();
    }
    public void WalkTheLine(float _start, float _final) // starting position must be less than the final!!!
    {
        if (this.gameObject.transform.position.x <= _start)
        {
            _direction = 1; 
        }
        if (this.gameObject.transform.position.x >= _final)
        {
            _direction = -1;
        }
        Walking(_direction);
    }

}
