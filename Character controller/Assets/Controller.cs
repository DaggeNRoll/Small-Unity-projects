
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]private Vector2 _inputVector;
    [SerializeField]private Vector2 _mouseInput;
    private bool _isJumpPressed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private float speed;
    [SerializeField] private float jumpInput;
    private bool _isGrounded;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float mouseVertPositiveConstraint;
    [SerializeField] private float mouseVertNegativeConstraint;
    [SerializeField] private float mouseHorPositiveConstraint;
    [SerializeField] private float mouseHorNegativeConstraint;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private float runMultiplier=2f;
    [SerializeField]private float _runInput;
    [SerializeField] private Animator _animator;
    private bool _isBlocking;
    private bool _isAttacking;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        transform.localRotation=Quaternion.Euler(/*-_mouseInput.y*/0,_mouseInput.x,0);
        if (_isBlocking)
        {
            HandleBlock();
            return;
        }

        if (_isAttacking)
        {
            HandleAttack();
            return;
        }
    }

    private void FixedUpdate()
    {
        if (_isBlocking)
        {
            return;
        }

        _animator.SetBool("IsBlocking", false);

        if (_isAttacking)
        {
            return;
        }
        
        MovementHandling();
        JumpingHandling();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _isGrounded = false;
        }
    }

    private void GetInput()
    {
        _inputVector.x = Input.GetAxis("Horizontal");
        _inputVector.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");
        _runInput = Input.GetAxisRaw("Run");
        
        _mouseInput.x += Input.GetAxis("Mouse X")*mouseSensitivity;

        var currentInputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (_mouseInput.y + currentInputY <= 7f && _mouseInput.y + currentInputY >=-7f)
        {
            _mouseInput.y += currentInputY;
        }

        _isBlocking = Input.GetButton("Fire2");
        _isAttacking = Input.GetButtonDown("Fire1");

    }

    private void MovementHandling()
    {
        float speedMultiplier = 1;
        if (_runInput > 0)
        {
            speedMultiplier = runMultiplier;
            _animator.SetBool("IsRunning",true);
        }
        else
        {
            _animator.SetBool("IsRunning",false);
        }
       
        _animator.SetFloat("VerticalInput",_inputVector.y);
        _animator.SetFloat("HorizontalInput",_inputVector.x);
        
        _rigidbody.AddRelativeForce(transform.forward +new Vector3(_inputVector.x,0,_inputVector.y) * (speed * speedMultiplier));
        _animator.SetFloat("Velocity",_rigidbody.velocity.magnitude);
    }

    private void JumpingHandling()
    {
        if (_isGrounded&&jumpInput>0)
        {
            _rigidbody.AddRelativeForce( new Vector3(0,jumpInput,0).normalized*jumpSpeed,ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    private void HandleBlock()
    {
        _animator.SetBool("IsBlocking",true);
        
    }

    private void HandleAttack()
    {
        _animator.SetTrigger("Attack");
    }
}
