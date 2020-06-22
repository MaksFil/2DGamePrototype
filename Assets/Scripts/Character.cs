using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform levelCheck;

    public float _speed, jumpForce, _health, maxHealth, _damage, attackReset, attackTime = 0f, checkRadius = 0.5f;
    public bool isAttacking = false, isDamage = false, withHammer;

    private Animator _animator;
    private Rigidbody2D _physics;

    private bool isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _physics = GetComponent<Rigidbody2D>();
    }
    public void Idle() 
    {
        _animator.SetFloat("walking", 0);
    }

    public virtual void Walking(int direction)
    {
        _animator.SetFloat("walking", direction);
        if (direction > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (direction < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.Translate(_speed, 0, 0);
    }
    public virtual void Attack()
    {
        _animator.SetBool("AttackWithHammer", true);
        isAttacking = true;
        isDamage = false;
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(levelCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            _physics.velocity = Vector2.up * jumpForce;
        }
    }
    public void AdjustedHealth(float adjust) 
    {
        _health += adjust;
    }

   public virtual void Death() 
    {
        Destroy(this.gameObject);
    }
    public void AttackTimer()
    {
        if (isAttacking)
        {
            if (attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                _animator.SetBool("AttackWithHammer", false);
                isDamage = false;
            }
        }
    }

}

