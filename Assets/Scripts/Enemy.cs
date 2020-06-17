using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    public override void CheckDeath() 
    {
        if(_health <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
