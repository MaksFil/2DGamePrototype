using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public float _speed, jumpForce, _health, maxHealth, _damage;

    public void Walking(int rotate)
    {
        transform.rotation = Quaternion.Euler(0, rotate, 0);
        if(rotate == 0) transform.Translate(_speed, 0, 0, Space.World);
        if(rotate == 180) transform.Translate(-_speed, 0, 0, Space.World);
    }
    public void AdjustedHealth(float adjust) 
    {
        _health += adjust;
    }

    public virtual void CheckDeath() 
    {
        if(_health <= 0) 
        {
        
        }
    }
}

