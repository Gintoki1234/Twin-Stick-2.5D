using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour
{
    public float panSpeed = 100f;
    private GameObject player;
    private Vector3 armRotation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        armRotation.y += Input.GetAxis("RightHoriz") * panSpeed * Time.deltaTime;
        armRotation.z += Input.GetAxis("RightVert") * panSpeed * Time.deltaTime;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler (armRotation);
    }
}
