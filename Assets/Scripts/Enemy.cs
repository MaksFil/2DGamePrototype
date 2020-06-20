using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private Transform _player;

    private NavMeshAgent _agent;

    private int _direction;
    private float _distance, lockRadius = 25;
    public bool isChase = false;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
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
        if (this.gameObject.transform.position.x >= final)
        {
            _direction = -1;
        }
        Walking(_direction);
    }
    public void Chase() 
    {
        _distance = Vector3.Distance(_player.position, transform.position);

        if(_distance <= lockRadius) 
        {
            _agent.SetDestination(_player.position);
            isChase = true;
        }
        else 
        {
            isChase = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lockRadius);
    }
}
