using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    Vector3 follow;
    Vector3 offset;
    void Start()
    {
        offset = transform.position;
        follow = objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        follow = objectToFollow.transform.position;
        transform.position = follow + offset;
    }
}
