using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMovement : MonoBehaviour
{
    [SerializeField] private STurnManager manager;
  
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
            SActivePlayer currentPlayer = manager.GetCurrentPlayer();

            if (Input.GetAxis("Horizontal") != 0)
            {                              
                currentPlayer.transform.Translate(transform.right * movespeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {                              
                currentPlayer.transform.Translate(transform.forward * movespeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {               
                currentPlayer.GetComponent<SWeapon>().EnableLineRenderer();
                currentPlayer.GetComponent<SWeapon>().ShootWeapon();
                manager.ChangeTurn();               
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //if (Input.GetKeyDown(KeyCode.Space) && ContactWithGround())
                
                currentPlayer.DoJump();
            }           
            currentPlayer.ReadRotationInput();
        }       
    }
  
  /*  private bool ContactWithGround()
    {
        RaycastHit groundCheck;
        return Physics.SphereCast(transform.position, 0.5f, -transform.up, out groundCheck, 1f);
        
    }
  */
}
