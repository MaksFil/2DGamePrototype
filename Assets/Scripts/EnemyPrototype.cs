using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : Enemy {

    [SerializeField] private float _start, _end;
    private void Update()
    {
        AttackTimer();
    }
    private void FixedUpdate() 
    {
        WalkTheLine(_start, _end);
    }
}
