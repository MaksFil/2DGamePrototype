using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : Enemy {
    private void Update()
    {
        WalkTheLine(-110, -85);
        AttackTimer();
    }
}
