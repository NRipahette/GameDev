using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float current_speed = 1;
    private float turning_speed = 0.1f;
    private float NormalMovementSpeed = 1;
    private float AttackMovementSpeed = 0.2f;
    public float JumpForce = 100;
    public float speed = 0;
    public float Walkspeed = 0;
    private bool isRotating = false;
    private bool IsGrounded = false;
    private Vector3 lastPosition = Vector3.zero;
    private float distToGround;
    private CameraCollision my_camera;
    private Animator myAnimator;
    private Rigidbody body;
    private Vector3 _inputs = Vector3.zero;
    private Vector3 desired_dir;

    // Start is called before the first frame update
    void Start()
    {
        my_camera = FindObjectOfType<CameraCollision>();
        myAnimator = GetComponentInChildren<Animator>();
        lastPosition = transform.position;
        //distToGround = GetComponentInChildren<BoxCollider>().bounds.extents.y;
        body = GetComponent<Rigidbody>();
        desired_dir = new Vector3(my_camera.gameObject.transform.forward.x, 0, my_camera.gameObject.transform.forward.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        desired_dir = new Vector3(my_camera.gameObject.transform.forward.x, 1, my_camera.gameObject.transform.forward.z);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
/*
        if (IsGrounded)
        {
            if (myAnimator.GetBool("IsJumping")) { myAnimator.SetBool("IsJumping", false); }
            else if (Should_jump()) { Jump(); };
            if (Should_ilde()) { Idle(); };

        }*/
        //if (Should_walk_forward()){ walk_forward(); } else { myAnimator.SetBool("IsWalkingForward", false); };
        //if (Should_walk_left()) { Walk_left(); }else{ myAnimator.SetBool("IsWalkingLeft", false); };
        //if (Should_walk_backward()) { walk_backward(); } else { myAnimator.SetBool("IsWalkingBackward", false); };
        //if (Should_walk_right()) { Walk_right(); } else { myAnimator.SetBool("IsWalkingRight", false); };

        if (Should_attack()) { Attack(); };

        //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * turning_speed);
        if (Should_rotate()) { Rotate(); };


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(JumpForce * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        //if (Input.GetButtonDown("Dash"))
        //{
        //    Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime)));
        //    body.AddForce(dashVelocity, ForceMode.VelocityChange);
        //}

        body.MovePosition(body.position + Vector3.Scale( _inputs , desired_dir) * Walkspeed * Time.fixedDeltaTime);
    }


    /*private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Terrain")
        {

            IsGrounded = true;
            myAnimator.SetBool("IsAirborne", false);
            myAnimator.SetBool("IsJumping", false);

        }
        else
        {
            IsGrounded = false;
            myAnimator.SetBool("IsAirborne", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Terrain")
        {

            IsGrounded = true;
            myAnimator.SetBool("IsAirborne", false);

        }
        else
        {
            IsGrounded = false;
            myAnimator.SetBool("IsAirborne", true);

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Terrain")
        {

            IsGrounded = false;
            myAnimator.SetBool("IsAirborne", true);
        }
    }
    */

    /*private bool IsGrounded() {
        
       
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }*/



    private void LateUpdate()
    {
       
    }

    private void Rotate()
    {
        SetRotate(this.gameObject, my_camera.gameObject);
    }
    
    void SetRotate(GameObject toRotate, GameObject camera)
    {
        Vector3 desired_dir = new Vector3 (camera.transform.forward.x, 0, camera.transform.forward.z);

        
        //toRotate.transform.Rotate(transform.rotation.x,camera.transform.localRotation.y,transform.rotation.z);
        //You can call this function for any game object and any camera, just change the parameters when you call this function
       transform.localRotation = Quaternion.Slerp(toRotate.transform.rotation, Quaternion.LookRotation(desired_dir,Vector3.up), turning_speed);
    }

    private bool Should_rotate()
    {
        if (transform.rotation.eulerAngles.y != my_camera.transform.localRotation.eulerAngles.y && myAnimator.GetBool("IsMoving"))
            isRotating = !isRotating;
        return isRotating;
    }

    private void Idle()
    {
        myAnimator.ResetTrigger("Attack");
        myAnimator.SetBool("IsWalkingForward", false);
        myAnimator.SetBool("IsWalkingBackward", false);
        myAnimator.SetBool("IsWalkingRight", false);
        myAnimator.SetBool("IsWalkingLeft", false);
        myAnimator.SetBool("IsAttacking", false);
        myAnimator.SetBool("IsMoving", false);
        myAnimator.SetBool("IsIdle", true);

    }

    private bool Should_ilde()
    {


        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        if (speed <= 0.01 && speed <= 0.01 )
            return true;
        else
            return false;
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
        //myAnimator.SetBool("IsAttacking",true);
    }

    private bool Should_attack()
    {
        return Input.GetKey(KeyCode.E);
    }

    private void Jump()
    {

        //GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        myAnimator.SetBool("IsJumping",true);
    }

    private bool Should_jump()
    {
        return Input.GetKey(KeyCode.Space);
    }

   /* private bool Should_walk_right()
    {
        return Input.GetKey(KeyCode.D);
    }

    private bool Should_walk_backward()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void walk_backward()
    {
        transform.position += -current_speed * transform.forward * Time.deltaTime;
        myAnimator.SetBool("IsWalkingBackward", true);
        myAnimator.SetBool("IsMoving", true);

    }
    

    private void Walk_left()
    {
        transform.position += -current_speed * transform.right * Time.deltaTime;
        myAnimator.SetBool("IsWalkingLeft", true);
        myAnimator.SetBool("IsMoving", true);

        //transform.Rotate(Vector3.up, -turning_speed * Time.deltaTime);
    }

    private void Walk_right()
    {
        transform.position += current_speed * transform.right * Time.deltaTime;
        myAnimator.SetBool("IsWalkingRight", true);
        myAnimator.SetBool("IsMoving", true);

        //transform.Rotate(Vector3.up, turning_speed * Time.deltaTime);
    }

    private bool Should_walk_left()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void walk_forward() {
        transform.position += current_speed * transform.forward*Time.deltaTime * 2;
        myAnimator.SetBool("IsWalkingForward",true);
        myAnimator.SetBool("IsMoving",true);
        myAnimator.SetBool("IsIdle", false);
    }


    private bool Should_walk_forward()
    {
        return Input.GetKey(KeyCode.W);
    }*/


    internal void RotatePlayer(float RotationY) {
       // transform.rotation.eulerAngles.y =  RotationY;
            //transform.Rotate(Vector3.up, RotationY);
            //transform.rotation.x, RotationY, transform.rotation.z, transform.rotation.w);
    }

    internal void SetAttackMovementSpeed()
    {
        current_speed = AttackMovementSpeed;
    }

    internal void SetNormalMovementSpeed()
    {
        current_speed = NormalMovementSpeed;
    }
}
