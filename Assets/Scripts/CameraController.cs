﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    
    [SerializeField]
    float back;
    [SerializeField]
    float up;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position =  new Vector3(target.position.x, target.position.y + up, target.position.z - back);
        transform.position = position;
    }
}
