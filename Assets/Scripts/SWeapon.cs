using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDmg;
    [SerializeField] private Transform weaponDirection;
    [SerializeField] private LineRenderer weaponLine;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Start()
    {
        float t = 0; //den här funkade inte som tänkt
    }
    public void ShootWeapon()
    {
        
        float t =+ Time.deltaTime;
        float lineTime = 5;
        if (t == 5)
        {
            t = 0;
        }
        //den här funkade inte som tänkt

        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponDirection.position, transform.forward, out result, Mathf.Infinity);

        weaponLine.SetPosition(0, weaponDirection.position);
        if (t < lineTime) //den här funkade inte som tänkt
        {
            weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den här funkade inte som tänkt
        }

        if (thereWasHit)
        {
            SHealth activePlayerHP = result.collider.GetComponent<SHealth>();
            if (activePlayerHP != null) //om hp på det raycast kolliderar med inte är null kommer nedstående ske.
            {
                activePlayerHP.TakeDmg(weaponDmg);
            }
            weaponLine.SetPosition(1, result.point);
            if (t > lineTime) //den här funkade inte som tänkt
            {
                weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den här funkade inte som tänkt
            }
        }
        else
        {

            weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 50);
            if (t < lineTime) //den här funkade inte som tänkt
            {
                weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den här funkade inte som tänkt
            }
        }
        
        

    }

    void Update() //THIS IS FOR PROJECTILE
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<SProjectile>().Initialize();
        }

        
    }
}
