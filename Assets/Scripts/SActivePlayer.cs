using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SActivePlayer : MonoBehaviour
{
    private STurnManager manager;

    [SerializeField] float jumpHeight;
    protected Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void AssignManager(STurnManager newManager)
    {
        manager = newManager;
    }

    public void ShotWeapon()
    {
        ChangeColor();
        manager.ChangeTurn();
    }

    public void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void DoJump()
    {


        rb.AddForce(Vector3.up * jumpHeight);
        //its better to use vector3 here than transform since transform will add the force from the characters perspective while vector3
        //will add the force in the upward direction based on the worlds perspective. 


    }
}
