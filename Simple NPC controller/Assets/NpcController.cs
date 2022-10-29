using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 _targetPosition => new Vector3(target.transform.position.x, 0, target.transform.position.z);
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        transform.LookAt(_targetPosition);
        target.GetComponent<Spot>().OnNpcReached += OnSpotReached;
        _anim.SetBool("isWalking",true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_targetPosition);
    }

    private void OnSpotReached(object sender, EventArgs args)
    {
        _anim.SetBool("isWalking",false);
    }
}
