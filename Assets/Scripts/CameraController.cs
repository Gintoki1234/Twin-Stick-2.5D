﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    Vector3 follow;
    Vector3 offset;
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position;
        follow = objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        follow = objectToFollow.transform.position;
        transform.position = follow + offset;        
        Debug.Log("RightHoriz is " + Input.GetAxis("RightHoriz"));
        Debug.Log("RightVert is " + Input.GetAxis("RightVert"));
    }
}
