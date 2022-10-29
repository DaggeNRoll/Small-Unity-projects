using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool HasItem { get; set; }

    public bool HasTask { get; set; }
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        HasItem = false;
        HasTask = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
