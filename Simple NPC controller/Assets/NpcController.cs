using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 _targetPosition;
    private Animator _anim;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject[] constraints;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        ChooseTarget();
        transform.LookAt(_targetPosition);
        target.GetComponent<Spot>().OnNpcReached += OnSpotReached;
        _anim.SetBool("isWalking",true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) < 2f)
        {
            ChooseTarget();
        }
        transform.LookAt(_targetPosition);
        var direction = transform.position - _targetPosition;
        transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotationSpeed);
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
        Debug.Log(_targetPosition);
    }
}
