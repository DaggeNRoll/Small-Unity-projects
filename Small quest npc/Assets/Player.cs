using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Animator _anim;

    private Rigidbody2D _rb;

    private Vector2 _input;

    private float _inputX;

    private float _inputY;

    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");
        
        _anim.SetFloat(MoveX,_rb.velocity.x);
        _anim.SetFloat(MoveY, _rb.velocity.y);

        if (_inputX * transform.localScale.x < 0)
        {
            var currentScale = transform.localScale;
            transform.localScale = new Vector3(currentScale.x*-1,currentScale.y,currentScale.z);
        }
        
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_inputX,_inputY).normalized*_speed);
    }
}
