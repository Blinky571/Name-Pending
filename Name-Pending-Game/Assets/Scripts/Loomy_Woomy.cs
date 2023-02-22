using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loomy_Woomy : MonoBehaviour
{
    private Transform _wallCheck;
    private LayerMask _wallLayer;
    private Rigidbody2D _rb;
    private int _horizontal;
    private Animator animator;

    private bool _FacingRight;

    private float timeRemaining;
    private bool timerIsRunning = false;
    private float startspeed;
    public float speed;


    private void Awake()
    {
        _wallLayer = LayerMask.GetMask("Player");
        _wallCheck = gameObject.transform.Find("wallCheck");
        _rb = gameObject.GetComponent<Rigidbody2D>();
        float randomNumber = Random.Range(15, 50);
        timeRemaining = randomNumber;
        timerIsRunning = true;
        startspeed = speed;
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", true);
    }

    private void Update()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("Moving", false);
                speed = 0;
                timerIsRunning = false;
                float randomNumber = Random.Range(2, 5);
                timeRemaining = randomNumber;
            }
        }

        if (timerIsRunning == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                speed = startspeed;
                timerIsRunning = true;
                float randomNumber = Random.Range(15, 50);
                timeRemaining = randomNumber;
            }
        }

        if (_FacingRight)
        {
            _horizontal = 1;
        }
        else
        {
            _horizontal = -1;
        }

        _rb.velocity = new Vector2(_horizontal * speed, _rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(_wallCheck.transform.position, Vector2.down, 1f);
       
        if (IsWall() || hit.collider == null)
        {
            Flip();
        }

        Debug.DrawLine(_wallCheck.transform.position, Vector2.down, Color.red);

    }


    void Flip()
    {
        if (!_FacingRight || _FacingRight)
        {
            _FacingRight = !_FacingRight;
            Vector2 _currentScale = gameObject.transform.localScale;
            _currentScale.x *= -1;
            transform.localScale = _currentScale;
        }
    }

    private bool IsWall()
    {
        return Physics2D.OverlapCircle(_wallCheck.position, .2f, _wallLayer);
    }
}
