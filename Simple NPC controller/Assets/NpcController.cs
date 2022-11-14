using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField]private Vector3 _targetPosition;
    private Animator _anim;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject[] constraints;
    [SerializeField] private float waitTime;
    private bool _isGameRunning;
    private float _lastTime;
    private Quaternion _currentRotation;
    private Rigidbody _rb;

    public UnityEvent playerCollision;
    private bool _isKeyPressed;
    private bool _dialogFlag;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        ChooseTarget();
        transform.LookAt(_targetPosition);
        target.GetComponent<Spot>().OnNpcReached += OnSpotReached;
        _anim.SetBool("isWalking",true);
        _isGameRunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       // _isKeyPressed = Input.GetKeyDown(KeyCode.E);
        _currentRotation = transform.rotation;
        if (Vector3.Distance(transform.position, _targetPosition) < 2f)
        {
            _anim.SetBool("isWalking",false);
            if (Time.time < _lastTime + waitTime)
            {
                //Debug.Log($@"1 : {Time.time}  2 : {_lastTime+waitTime} Time scale : {Time.timeScale}");
                _rb.constraints = RigidbodyConstraints.FreezeRotation;
                //transform.LookAt(transform.position);
                return;
            }

            _rb.constraints = RigidbodyConstraints.FreezeRotationX;
            _lastTime = Time.time;
            ChooseTarget();
            
        }
        _anim.SetBool("isWalking",true);
        
        transform.LookAt(_targetPosition);
        var direction = transform.position - _targetPosition;
        //transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotationSpeed);
    }

    private void OnSpotReached(object sender, EventArgs args)
    {
        //ChooseTarget();
    }

    private void ChooseTarget()
    {
        _targetPosition = new Vector3(
            Random.Range(constraints[1].transform.position.x, constraints[0].transform.position.x), 0f,
            Random.Range(constraints[3].transform.position.z, constraints[2].transform.position.z));
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || _dialogFlag) return;
        playerCollision.Invoke();
        _dialogFlag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        _dialogFlag = false;
    }
}
