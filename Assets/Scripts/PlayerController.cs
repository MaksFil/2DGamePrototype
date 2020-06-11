using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float _speed = 0.1f, jumpForce = 3;
    
    private Animator _animator;
    private Rigidbody2D _physics;

    static public bool isAttacking = false, _damage = false;

    private float checkRadius = 0.5f, attackTimer = 0f, attackReset = 0.2f;
    private int _direction;
    private bool isGrounded;
    private bool withHammer = true; 

    private void Walking(int rotate)
    {
        transform.rotation = Quaternion.Euler(0, rotate, 0);
        transform.Translate(_speed, 0, 0);
    }
    public void OnClickMoveButton(int direction)
    {
        _animator.SetFloat("walking", direction);
        _direction = direction;
    }

    public void OnClickJumpButton()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            _physics.velocity = Vector2.up * jumpForce;
        }
    }
    public void OnClickHammerAttackButton() 
    {
        if(withHammer) 
        {
            isAttacking = true;
            attackTimer = attackReset;
            _animator.SetBool("AttackWithHammer", true);
            _damage = false;
        }
    }

    private void Start() 
    {

        _animator = GetComponent<Animator>();
        _physics = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                _animator.SetBool("AttackWithHammer", false);
                _damage = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_direction > 0) Walking(0);
        else if (_direction < 0) Walking(180);
        else _animator.SetFloat("walking", 0);
    }
}
