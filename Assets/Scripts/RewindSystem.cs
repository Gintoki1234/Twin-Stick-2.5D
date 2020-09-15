using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSystem : MonoBehaviour
{
    private List<MyKeyFrame> myKeyFrameList;
    private Rigidbody rigidBody;
    private GameManager manager;

    //public float rewindTimeLimit = 4f;
    public int rewindFrameLimit = 500;

    void Start()
    {
        myKeyFrameList = new List<MyKeyFrame>();
        rigidBody = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(manager.recording)
        {
            Record();
        }
        else
        {
            Rewind();
        }
    }

    private void Rewind()
    {
        if (myKeyFrameList.Count > 0 )
        {
            rigidBody.isKinematic = true;
            MyKeyFrame myKeyFrame = myKeyFrameList[0];            
            transform.position = myKeyFrame.position;
            transform.rotation = myKeyFrame.rotation;
            myKeyFrameList.RemoveAt(0);
        }

    }
    private void Record()
    {
        rigidBody.isKinematic = false;
        //if (myKeyFrameList.Count > Mathf.Round(rewindTimeLimit * (1 / Time.fixedDeltaTime)))
        if (myKeyFrameList.Count > rewindFrameLimit)
        {
            myKeyFrameList.RemoveAt(myKeyFrameList.Count - 1);
        }
        myKeyFrameList.Insert(0, new MyKeyFrame(transform.position, transform.rotation));
    }
}
public class MyKeyFrame
{
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(Vector3 aPosition, Quaternion aRotation)
    {
        position = aPosition;
        rotation = aRotation;
    }
}
