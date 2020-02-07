using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{


    private GameObject Player;
    private float cameraSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, Player.transform.position, cameraSpeed);
        //transform.position = (Player.transform.position - transform.position) * Time.deltaTime;
    }
}
