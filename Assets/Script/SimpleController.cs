using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class SimpleController : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _moveInput;
    private bool _isFacingRight = true;
      
    private void Start()
    {      
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();      
    }

    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_moveInput * _speed, _rigidbody2D.velocity.y); 
        
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        if(_moveInput>0 && IsGrounded() || _moveInput<0 && IsGrounded())
        {
            _animator.SetBool(RunAnimController.Params.IsRunning, true);
        }
        else 
        {
            _animator.SetBool(RunAnimController.Params.IsRunning, false);
        }
       
        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position,_checkRadius,_groundMask);
    }

    private void Flip()
    {
        if(_isFacingRight && _moveInput<0 || !_isFacingRight && _moveInput > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
public static class RunAnimController
{
    public static class Params
    {
        public const string IsRunning = "IsRunning";
    }
}
