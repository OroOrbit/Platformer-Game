using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class platfomer1 : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _animator;
    private Playerlife _playerlife;

    public float speed = 5f;
    public float jumpForce = 5f;
    public float radius = 0.2f;

    private bool _jumpToConsume;
    private int _jumps;
    private bool _isGrounded;
    public Transform groundChecker;
    public LayerMask groundLayer;

    private float _horizontal;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerlife = GetComponent<Playerlife>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (!_playerlife.isAlive) return;
        _horizontal = Input.GetAxis("Horizontal");
       
        if (IsGrounded())
        {
            _jumps = 0;
        }

        if (_jumps < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpToConsume = true;

        }

        FlipPlayer();

        UpdateAnimation();

    }

    private void FixedUpdate()
    {
        if (!_playerlife.isAlive) return;
        _rb.linearVelocity = new Vector2(_horizontal * speed, _rb.linearVelocity.y);

        if (_jumpToConsume)
        {
            ExecuteJump();
        }
    }

    void FlipPlayer()
    {
        if (_rb.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (_rb.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void UpdateAnimation()
    {
        if (_rb.linearVelocity.x == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }

        if (_rb.linearVelocity.y == 0 && IsGrounded())
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", false); 
        }

        if (_rb.linearVelocity.y > 0 && !IsGrounded())
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }

        if (_rb.linearVelocity.y < 0 && !IsGrounded())
        {
            _animator.SetBool("isFalling", true);
            _animator.SetBool("isJumping", false);
        }
    }

    void ExecuteJump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        _jumps = _jumps + 1;
        _jumpToConsume = false;
    }

    bool IsGrounded()
    {
        bool groundCheck = Physics2D.OverlapCircle(groundChecker.position, radius, groundLayer);
        return groundCheck;
    }
    
}

   

