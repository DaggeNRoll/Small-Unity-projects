using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerStates _currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _currentState = PlayerStates.IDLE;
        EnterState(_currentState);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    public void SwitchState(PlayerStates state)
    {
        _currentState = state;
        EnterState(_currentState);
    }

    private void EnterState(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.IDLE:

                break;
            case PlayerStates.WALK:

                break;
            case PlayerStates.JUMP:

                break;
            case PlayerStates.RUN:

                break;
            case PlayerStates.ATTACK:

                break;
        }
    }

    private void UpdateState()
    {
        switch (_currentState)
        {
            case PlayerStates.IDLE:

                break;
            case PlayerStates.WALK:

                break;
            case PlayerStates.JUMP:

                break;
            case PlayerStates.RUN:

                break;
            case PlayerStates.ATTACK:

                break;
        }
    }
    
}

public enum PlayerStates
{
    IDLE,
    WALK,
    RUN,
    JUMP,
    ATTACK
}
