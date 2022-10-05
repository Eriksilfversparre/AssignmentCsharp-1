using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDmg;
    [SerializeField] private Transform weaponDirection;
    [SerializeField] public LineRenderer weaponLine;

    /* For projectile
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    */

    public void ShootWeapon()
    {      
        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponDirection.position, transform.forward, out result, Mathf.Infinity);
        Debug.DrawRay(transform.position, transform.forward * 25f, Color.green, 0.2f);
        weaponLine.SetPosition(0, weaponDirection.position);

        {
            weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5);

            if (thereWasHit)
            {
                SHealth activePlayerHP = result.collider.GetComponent<SHealth>();
                if (activePlayerHP != null) 
                {
                    activePlayerHP.TakeDmg(weaponDmg);
                }
                weaponLine.SetPosition(1, result.point);
            }
            else
            {
                weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 50);
            }
            Invoke("DisableLineRenderer", 1);
        }       
    }

    public void DisableLineRenderer()
    {
        weaponLine.enabled = false;
    }
    public void EnableLineRenderer()
    {
        weaponLine.enabled = true;
    }

    /* For projectile
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<SProjectile>().Initialize();
        }
    }*/
}
