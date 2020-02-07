using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    private Vector3 CamPosition;
    private GameObject FocusPoint;
    private GameObject Player;
    private Vector3 Offset;
    private float LastRotY;
    private float RotationY;
    // Start is called before the first frame update
    void Start()
    {
        CamPosition = transform.position;
        FocusPoint = GameObject.FindGameObjectWithTag("CameraFocus");
        Player = GameObject.FindWithTag("Player");
        Debug.Log(FocusPoint.transform.position);
    }

    //// LateUpdate is called after Update each frame
    //void LateUpdate()
    //{
    //    // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    //    transform.position = player.transform.position + offset;
    //}
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Mouse Y"));
        Quaternion CamTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
        CamPosition = CamTurnAngle * CamPosition;

        Quaternion CamTurnAngleY = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right);
        CamPosition = CamTurnAngleY * CamPosition;



        transform.localPosition = CamPosition;

        transform.LookAt(FocusPoint.transform);

        RotationY = transform.rotation.y;


        //Player.RotatePlayer(RotationY);
        //Debug.Log(transform.localRotation.y*100);
        // Debug.Log(transform.rotation.y*100);

        LastRotY = transform.rotation.y;
    }

    internal void Follow(PlayerMovement player)
    {
        //transform.parent = player.transform;
    }

    internal void Disconnect(PlayerMovement player)
    {
        //check to see if this camera is connected to the passed character
        transform.parent = null;
    }
}
