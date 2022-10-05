using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SActivePlayer : MonoBehaviour
{
    private STurnManager manager;

    //jump
    [SerializeField] float jumpHeight;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    protected Rigidbody rb;


    //rotation
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float pitchClamp = 90;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AssignManager(STurnManager newManager)
    {
        manager = newManager;
    }

    //test for turn change
    public void ButtonTurnChange()
    {
        ChangeColor();
        manager.ChangeTurn();
    }
    public void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    //jump
    public void DoJump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }    
    }
    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }


    //rotation
    public void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

}
