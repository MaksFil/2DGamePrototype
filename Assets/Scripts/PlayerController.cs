using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    private Animator _animator;
    private Rigidbody2D _physics;
    private float checkRadius = 0.5f;
    [SerializeField] private float _speed = 0.1f, jumpForce = 3;
    private int _direction;
    private bool isGrounded;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        _physics = GetComponent<Rigidbody2D>();
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(isGrounded) 
        {
            _physics.velocity = Vector2.up * jumpForce;
        }
    }
}
