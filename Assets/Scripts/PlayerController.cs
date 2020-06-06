using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float _speed = 0.1f;
    private Animator _animator;
    private int _direction;
    [SerializeField] private float heightJump = 3;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Walking(int rotate) 
    {
        transform.rotation = Quaternion.Euler(0, rotate, 0);
        transform.Translate(_speed, 0, 0);
    }

    private void Update()
    {
        if (_direction > 0) Walking(0);
        else if (_direction < 0) Walking(180);
        else _animator.SetFloat("walking", 0);
    }

    public void OnClickMoveButton(int direction) 
    {
        _animator.SetFloat("walking", direction);
        _direction = direction;
    }

    public void OnClickJumpButton() 
    {
        
    }
}
