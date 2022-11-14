using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float stopFlag;
    [SerializeField]private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        // _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isWalking", !(_controller.velocity.magnitude < stopFlag));
    }
}
