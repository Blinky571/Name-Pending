using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public ParticleSystem dust;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _groundCheck;
    private LayerMask _groundLayer;

    private float _moveInput;
    private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;

    #region Player Speeds
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;
    #endregion

    private bool _FacingRight = true;
    private bool _isJogging;
    private Vector2 _playerVelocity;


    private void Awake()
    {
        _groundLayer = LayerMask.GetMask("Ground");
        _groundCheck = transform.Find("groundCheck");
        _animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();        
    }


    private void Update()
    {
        if (IsGrounded())
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }

        
        _moveInput = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("isJogging", _isJogging);
        if (_moveInput != 0)
        {
            _isJogging = true;
            _animator.SetBool("isWaiting", false);
        }
        else
        {
            _isJogging = false;
        }
        if (_coyoteTimeCounter > 0f && Input.GetButtonDown("Jump") )
        {
            CreateDust();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
            _animator.SetBool("isWaiting", false);
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            _coyoteTimeCounter = 0f;
        }

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput * _playerSpeed, _rb.velocity.y);
    }
    void Flip()
    {
        if (_moveInput > 0 && !_FacingRight || _moveInput < 0 && _FacingRight)
        {
            _FacingRight = !_FacingRight;
            Vector2 _currentScale = gameObject.transform.localScale;
            _currentScale.x *= -1;
            transform.localScale = _currentScale;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
