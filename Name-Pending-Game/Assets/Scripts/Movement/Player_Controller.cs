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

    #region Player Speeds
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;
    #endregion

    private bool _FacingRight = true;
    private bool _isJogging;
    private Vector2 _playerVelocity;


    private void Awake()
    {
        _groundCheck = transform.Find("groundCheck");
        _animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();        
    }


    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        
        /*
        transform.Translate(_playerVelocity * Time.deltaTime);
        _animator.SetBool("isJogging", _isJogging);
        if (_moveInput != 0)
        {
            _playerVelocity.x = _moveInput * _playerSpeed;
            _isJogging = true;
            _animator.SetBool("isWaiting", false);
        }
        else
        {
            _playerVelocity.x = 0f;
            _isJogging = false;
        }
        */

        if (Input.GetButtonDown("Jump"))
        {
            CreateDust();
            _rb.AddForce(new Vector2(0, _jumpHeight));
            _animator.SetBool("isWaiting", false);
        }

        Flip();
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
