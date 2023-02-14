using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    #region Player Speeds
    [SerializeField]
    private float _playerSpeed;
    [SerializeField]
    private float _jumpHeight;
    #endregion

    public bool _isGrounded;
    private bool _FacingRight = true;
    private Vector2 _playerVelocity;
    private bool _isJogging;
    public ParticleSystem dust;


    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();        
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(_playerVelocity * Time.deltaTime);
        animator.SetBool("isJogging", _isJogging);
        if (moveInput != 0)
        {
            _playerVelocity.x = moveInput * _playerSpeed;
            _isJogging = true;
            animator.SetBool("isWaiting", false);
        }
        else
        {
            _playerVelocity.x = 0f;
            _isJogging = false;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            CreateDust();
            rb.AddForce(new Vector2(0, _jumpHeight));
            animator.SetBool("isWaiting", false);
        }

        if (moveInput < 0 && _FacingRight)
        {
            Flip();
        }
        if (moveInput > 0 && !_FacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector2 _currentScale = gameObject.transform.localScale;
        _currentScale.x *= -1;
        gameObject.transform.localScale = _currentScale;

        _FacingRight = !_FacingRight;
    }

    void CreateDust()
    {
        dust.Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
