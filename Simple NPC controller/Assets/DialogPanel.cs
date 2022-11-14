using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] private GameObject exitButton;

    [SerializeField] private GameObject okButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        exitButton.SetActive(false);
        okButton.SetActive(true);
    }
}
