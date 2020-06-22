using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private Transform _player;

    [SerializeField] private float maxHightTarget;

    private int _direction;
    private float distanceTarget, hightTarget;
    public bool isChase;

    public override void Attack()
    {
        if (withHammer && attackTime <= 0) base.Attack();
    }
    public void WalkTheLine(float start, float final) // starting position must be less than the final!!!
    {
        if (this.gameObject.transform.position.x <= start)
        {
            _direction = 1;
        }
        else if (this.gameObject.transform.position.x >= final)
        {
            _direction = -1;
        }
        Walking(_direction);
    }
    public void Chase(float lockRadius)
    {

        distanceTarget = _player.position.x - transform.position.x;
        hightTarget = Mathf.Abs(_player.position.y - transform.position.y);

        if (distanceTarget <= lockRadius && hightTarget <= maxHightTarget)
        {
            _speed = 0.14f;
            isChase = true;

            if (distanceTarget > 0)
            {
                _direction = 1;
            }

            if(distanceTarget < 0) 
            {
                _direction = -1;
            }

            Walking(_direction);
        }
        else
        {
            _speed = 0.1f;
            isChase = false;
        }
    }
}
