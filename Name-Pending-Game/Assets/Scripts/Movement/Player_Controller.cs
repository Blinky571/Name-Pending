using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Transform _popUpPrompt;
    public ParticleSystem dust;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _groundCheck;
    private SpriteRenderer _spi;
    private Transform _wallCheck;
    private LayerMask _groundLayer;
    private LayerMask _wallLayer;
    AudioSource audioSrc;
    
    private bool _FacingRight = true;
    private bool _isJogging;

    #region Move variables
    [SerializeField] private float _moveInput;
    private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;
    private float _jumpBufferTime = 0.2f;
    private float _jumpBufferTimeCounter;
    private bool _isWallSliding;
    private bool _isWallClimbing;
    private float _moveTime;


    #region Player Speeds
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _wallClimbSpeed;
    #endregion
    #endregion

    private void Start()
    {
        
        audioSrc = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        _popUpPrompt = transform.Find("popUpPrompt");
        _groundLayer = LayerMask.GetMask("Ground");
        _wallLayer = LayerMask.GetMask("Wall");
        _groundCheck = transform.Find("groundCheck");
        _wallCheck = transform.Find("wallCheck");
        _animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();  
        _spi =_popUpPrompt.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        _animator.SetBool("isWallsliding", _isWallSliding);
        if (!_FacingRight)
        {
            _spi.flipX = true;
        }
        else
        {
            _spi.flipX = false;
        }
        if (_isWallClimbing)
        {
            _animator.SetBool("isClimbing", true);
        }
        else
        {
            _animator.SetBool("isClimbing", false);
        }

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
            if (IsGrounded())
            {
                _moveTime = _moveTime + Time.deltaTime;
                _animator.SetBool("isWaiting", false);
                _isJogging = true;
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
            }
            else
            {
                audioSrc.Stop();
            }
        }
        else
        {
            _moveTime = 0;
            audioSrc.Stop();
            _isJogging = false;
        }
        if (_coyoteTimeCounter > 0f && _jumpBufferTimeCounter > 0f && !_isWallSliding && !_isWallClimbing)
        {
            _animator.SetTrigger("takeOff");
            _jumpBufferTimeCounter = 0f;
            dust.Play();
            SoundManagerScript.PlaySound("Jetpack");
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
        return Physics2D.OverlapCapsule(_wallCheck.position, new Vector2(0.1f, 2f), CapsuleDirection2D.Vertical, 0, _wallLayer);
    }
    private void WallSlide()
    {
        if (IsWalled() && _moveInput != 0f)
        {
            _isWallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue));
            if (Input.GetKey(KeyCode.W))
            {
                _isWallSliding = false;
                _isWallClimbing = true;
                _rb.velocity = new Vector2(_rb.velocity.x, _wallClimbSpeed);
            }
            else
            {
                _isWallClimbing = false;
            }
        }
        else
        {
            _isWallClimbing = false;
            _isWallSliding = false;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput * _playerSpeed, _rb.velocity.y);
        if (_moveTime > 1)
        {
            _playerSpeed = 6f;
        }
        else
        {
            _playerSpeed = 4.2f;
        }
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
