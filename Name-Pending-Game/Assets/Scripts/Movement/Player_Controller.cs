using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public ParticleSystem dust;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private float _moveInput;
    private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;
    private float _jumpBufferTime = 0.2f;
    private float _jumpBufferTimeCounter;

    private bool _isWallSliding;

    #region Player Speeds
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _wallClimbSpeed;
    #endregion

    private bool _FacingRight = true;
    private bool _isJogging;


    private void Awake()
    {
        _groundLayer = LayerMask.GetMask("Ground");
        //_wallLayer = LayerMask.GetMask("Wall");
        _groundCheck = transform.Find("groundCheck");
        //_wallCheck = transform.Find("wallCheck");
        _animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();        
    }
    private void Update()
    {
        if (IsGrounded())
        {
            _animator.SetBool("isJumping", false);
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _animator.SetBool("isJumping", true);
            _coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _jumpBufferTimeCounter = _jumpBufferTime;
        }
        else
        {
            _jumpBufferTimeCounter -= Time.deltaTime;
        }
        _moveInput = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("isJogging", _isJogging);
        if (_moveInput != 0)
        {
            _animator.SetBool("isWaiting", false);
            _isJogging = true;
        }
        else
        {
            _isJogging = false;
        }
        if (_coyoteTimeCounter > 0f && _jumpBufferTimeCounter > 0f)
        {
            _animator.SetTrigger("takeOff");
            _jumpBufferTimeCounter = 0f;
            dust.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
            _animator.SetBool("isWaiting", false);
        }
        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            _coyoteTimeCounter = 0f;
        }
        WallSlide();
        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(_wallCheck.position, 0.2f, _wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && _moveInput != 0f)
        {
            _isWallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue));
            dust.Play();
            if (Input.GetKey(KeyCode.W))
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _wallClimbSpeed);
            }
        }
        else
        {
            _isWallSliding = false;
        }
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
}
