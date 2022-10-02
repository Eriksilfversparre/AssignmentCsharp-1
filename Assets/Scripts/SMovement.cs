using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMovement : MonoBehaviour
{
    [SerializeField] private STurnManager manager;

    //Third Person Camera rot
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float pitchClamp = 90;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //CHaracter attributes
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public float rotSpeed;
    public float movespeed;
    


    private void Start()
    {
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (manager.CanPlay())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                SActivePlayer currentPlayer = manager.GetCurrentPlayer();
                //currentPlayer.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
                currentPlayer.transform.Translate(transform.right * movespeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                SActivePlayer currentPlayer = manager.GetCurrentPlayer();
                //currentPlayer.transform.Translate(Vector3.forward * movespeed * Time.deltaTime * Input.GetAxis("Vertical"));
                currentPlayer.transform.Translate(transform.forward * movespeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }


            if (Input.GetKeyDown(KeyCode.X))
            {
                SActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.GetComponent<SWeapon>().ShootWeapon();
                manager.ChangeTurn();
                

            }

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                //if (Input.GetKeyDown(KeyCode.Space) && ContactWithGround())
                SActivePlayer currentPlayer = manager.GetCurrentPlayer();
                currentPlayer.DoJump();
            }

            //ReadRotationInput();
        }
        
    }
  
       /* 
    private void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
       */

    private bool ContactWithGround()
    {
        RaycastHit groundCheck;
        return Physics.SphereCast(transform.position, 0.5f, -transform.up, out groundCheck, 1f);
        //first parameter is from where we shot the sphere, second is the volum of the spere (kinda), third is the direction of the sphere
        //forth (out) is the input we want, in this case RaycastHit(if we hit something). Last parameter is how far from the original positin the spehere will be.
    }
    
    
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
    
}
